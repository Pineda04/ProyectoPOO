using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoViajes.API.Database.Entities
{
    [Table("destination", Schema = "dbo")]
    public class DestinationEntity
    {
        // Id
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        // Nombre
        [StringLength(100)]
        [Required]
        [Column("name")]
        public string Name { get; set; }

        // Descripción
        [StringLength(500)]
        [Column("description")]
        public string Description { get; set; }

        // Ubicación
        [StringLength(100)]
        [Required]
        [Column("location")]
        public string Location { get; set; }

        // Fecha de registro
        [Column("registration_date")]
        public DateTime RegistrationDate { get; set; }

        // Puntos de interes
        [Column("points_interest")]
        public virtual IEnumerable<PointInterestEntity> PointsInterest { get; set; }

        // Imagen
        [Required]
        [Column("image_url")]
        public string ImageUrl { get; set; }
    }
}