using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDotnetPostgresApi.Models
{
    public class Persona
    {
        [Key]
        public string DocumentoIdentidad { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; }

        [Required]
        public DateOnly FechaNacimiento { get; set; }

    // Inicialización de colecciones
    public ICollection<DireccionFisica> DireccionesFisicas { get; set; } = new List<DireccionFisica>();
    public ICollection<NumeroTelefonico> NumerosTelefonicos { get; set; } = new List<NumeroTelefonico>();
    public ICollection<CorreoElectronico> CorreosElectronicos { get; set; } = new List<CorreoElectronico>();
    }
}