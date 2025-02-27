using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyDotnetPostgresApi.Data;
using MyDotnetPostgresApi.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyDotnetPostgresApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly ILogger<PersonasController> _logger;

        public PersonasController(IPersonaRepository personaRepository, ILogger<PersonasController> logger)
        {
            _personaRepository = personaRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            var personas = await _personaRepository.GetPersonasAsync();
            return Ok(personas);
        }

        [HttpPost]
        public async Task<ActionResult<Persona>> CreatePersona([FromBody] Persona persona)
        {
            _logger.LogInformation("Entrando a CreatePersona");

            // Validar que el modelo es válido
            if (persona == null)
            {
                _logger.LogWarning("El objeto persona es nulo.");
                return BadRequest("El objeto persona es nulo.");
            }

            _logger.LogInformation("Iniciando la creación de una nueva persona.");

            // Validar que no exista una persona con el mismo documento de identidad
            if ((await _personaRepository.GetPersonaByIdAsync(persona.DocumentoIdentidad)) != null)
            {
                _logger.LogWarning("Ya existe una persona con el mismo documento de identidad.");
                return BadRequest("Ya existe una persona con el mismo documento de identidad.");
            }

            // Validar que al menos una información de contacto esté presente
            if (persona.CorreosElectronicos.Count == 0 && persona.DireccionesFisicas.Count == 0)
            {
                _logger.LogWarning("Debe registrar al menos una información de contacto (correo electrónico o dirección física).");
                return BadRequest("Debe registrar al menos una información de contacto (correo electrónico o dirección física).");
            }

            // Validar que no se registren más de 2 números telefónicos, correos electrónicos o direcciones físicas
            if (persona.NumerosTelefonicos.Count > 2)
            {
                _logger.LogWarning("No se pueden registrar más de 2 números telefónicos.");
                return BadRequest("No se pueden registrar más de 2 números telefónicos.");
            }

            if (persona.CorreosElectronicos.Count > 2)
            {
                _logger.LogWarning("No se pueden registrar más de 2 correos electrónicos.");
                return BadRequest("No se pueden registrar más de 2 correos electrónicos.");
            }

            if (persona.DireccionesFisicas.Count > 2)
            {
                _logger.LogWarning("No se pueden registrar más de 2 direcciones físicas.");
                return BadRequest("No se pueden registrar más de 2 direcciones físicas.");
            }

            // Inicializar las colecciones de direcciones, teléfonos y correos antes de asociar la Persona
            foreach (var numero in persona.NumerosTelefonicos)
            {
                numero.Persona = persona;
                numero.PersonaDocumentoIdentidad = persona.DocumentoIdentidad;
            }

            foreach (var correo in persona.CorreosElectronicos)
            {
                correo.Persona = persona;
                correo.PersonaDocumentoIdentidad = persona.DocumentoIdentidad;
            }

            foreach (var direccion in persona.DireccionesFisicas)
            {
                direccion.Persona = persona;
                direccion.PersonaDocumentoIdentidad = persona.DocumentoIdentidad;
            }

            // Imprimir los datos antes de la validación
            _logger.LogInformation("Datos de la persona antes de la validación: {@Persona}", persona);

            // Validar el modelo manualmente
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(persona);
            if (!Validator.TryValidateObject(persona, validationContext, validationResults, true))
            {
                var errors = validationResults.Select(vr => new { vr.MemberNames, vr.ErrorMessage });
                _logger.LogWarning("Errores de validación: {@Errors}", errors);
                return BadRequest(new { errors });
            }

            // Guardar la persona en la base de datos
            await _personaRepository.AddPersonaAsync(persona);
            _logger.LogInformation("Persona creada exitosamente: {@Persona}", persona);

            return CreatedAtAction(nameof(GetPersonas), new { id = persona.DocumentoIdentidad }, persona);
        }
    }
}