using Microsoft.EntityFrameworkCore;
using MyDotnetPostgresApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDotnetPostgresApi.Data
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Persona>> GetPersonasAsync()
        {
            return await _context.Personas
                .Include(p => p.NumerosTelefonicos)
                .Include(p => p.CorreosElectronicos)
                .Include(p => p.DireccionesFisicas)
                .ToListAsync();
        }

        public async Task<Persona> GetPersonaByIdAsync(string documentoIdentidad)
        {
            return await _context.Personas
                .Include(p => p.NumerosTelefonicos)
                .Include(p => p.CorreosElectronicos)
                .Include(p => p.DireccionesFisicas)
                .FirstOrDefaultAsync(p => p.DocumentoIdentidad == documentoIdentidad);
        }

        public async Task AddPersonaAsync(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
        }
    }
}