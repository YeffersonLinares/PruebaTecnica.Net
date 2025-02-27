using MyDotnetPostgresApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDotnetPostgresApi.Data
{
    public interface IPersonaRepository
    {
        Task<IEnumerable<Persona>> GetPersonasAsync();
        Task<Persona> GetPersonaByIdAsync(string documentoIdentidad);
        Task AddPersonaAsync(Persona persona);
    }
}