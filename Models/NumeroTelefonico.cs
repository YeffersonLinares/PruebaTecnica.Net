using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDotnetPostgresApi.Models
{
    public class NumeroTelefonico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Numero { get; set; }

        // Esta propiedad solo se debe usar como referencia para establecer la relación
        [ForeignKey("Persona")]
        public string PersonaDocumentoIdentidad { get; set; }

        public Persona? Persona { get; set; }
    }
}