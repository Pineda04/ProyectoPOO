using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoViajes.API.Database.Entities
{
    [Table("assessments", Schema = "dbo")]
    public class AssessmentEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        public Guid PackageId { get; set; }

        [Required(ErrorMessage = "La {0} es requerida")]
        [Range(1, 5, ErrorMessage = "La {0} debe estar entre {1} y {2}")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [StringLength(500, ErrorMessage = "El {0} no puede exceder {1} caracteres")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "La {0} es requerida")]
        public DateTime Date { get; set; }
    }

}