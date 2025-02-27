using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDotnetPostgresApi.Models
{
    public class CorreoElectronico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [ForeignKey("Persona")]
        public string PersonaDocumentoIdentidad { get; set; }

        public Persona? Persona { get; set; }
    }
}