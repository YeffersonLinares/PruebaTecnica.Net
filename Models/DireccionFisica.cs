using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDotnetPostgresApi.Models
{
    public class DireccionFisica
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Direccion { get; set; }

        [ForeignKey("Persona")]
        public string PersonaDocumentoIdentidad { get; set; }

        public Persona? Persona { get; set; }
    }
}