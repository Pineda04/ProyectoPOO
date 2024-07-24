using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoViajes.API.Database.Entities
{
    [Table("destination", Schema ="dbo")]
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
        [StringLength(200)]
        [Required]
        [Column("location")]
        public string Location { get; set; }

        // Puntos de interes
        public virtual IEnumerable<PointInterestEntity> PointInterests { get; set; }

        // Para la relación con Paquete de viaje
        public virtual IEnumerable<TravelPackageEntity> TravelPackages  { get; set; }
    }
}
