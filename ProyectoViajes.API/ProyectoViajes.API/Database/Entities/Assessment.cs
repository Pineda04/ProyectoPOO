using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoViajes.API.Database.Entities
{
    [Table("assessments", Schema = "dbo")]
    public class AssessmentEntity
    {
        // Id
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        // Usuario Id

        [Required(ErrorMessage = "El {0} es requerido")]
        [Column("user_id")]
        public Guid UserId { get; set; }

        // Paquete de viaje Id
        [Required(ErrorMessage = "El {0} es requerido")]
        [Column("package_id")]
        public Guid PackageId { get; set; }

        [ForeignKey(nameof(PackageId))]
        public virtual TravelPackageEntity TravelPackage { get; set; }

        // Puntuación

        [Required(ErrorMessage = "La {0} es requerida")]
        [Range(1, 5, ErrorMessage = "La {0} debe estar entre {1} y {2}")]
        [Column("rating")]
        public int Rating { get; set; }

        // Comentario

        [Required(ErrorMessage = "El {0} es requerido")]
        [StringLength(500, ErrorMessage = "El {0} no puede exceder {1} caracteres")]
        [Column("comment")]
        public string Comment { get; set; }

        // Fecha 

        [Required(ErrorMessage = "La {0} es requerida")]
        [Column("rating_date")]
        public DateTime Date { get; set; }
    }

}