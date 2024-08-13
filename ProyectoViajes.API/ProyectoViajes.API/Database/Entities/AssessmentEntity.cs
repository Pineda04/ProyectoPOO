using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoViajes.API.Database.Entities
{
    [Table("assessment")]
    public class AssessmentEntity
    {
        // Id
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        // Usuario Id
        [Required]
        [Column("user_id")]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual UserEntity User { get; set; }

        // Paquete de viajes Id[Required]
        [Required]
        [Column("travel_package_id")]
        public Guid TravelPackageId { get; set; }
        [ForeignKey(nameof(TravelPackageId))]
        public virtual TravelPackageEntity TravelPackage { get; set; }

        // Puntuación (del 1 al 5)
        [Required]
        [Column("rating")]
        public int Rating { get; set; }

        // Comentario
        [StringLength(500)]
        [Required]
        [Column("comment")]
        public string Comment { get; set; }

        // Fecha de la valoración
        [Required]
        [Column("rating_date")]
        public DateTime RatingDate { get; set; }
    }
}