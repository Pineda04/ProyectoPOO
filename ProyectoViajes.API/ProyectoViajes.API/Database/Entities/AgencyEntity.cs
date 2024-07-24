using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoViajes.API.Database.Entities
{
    [Table("agency", Schema ="dbo")]
    public class AgencyEntity
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

        // Contacto
        [StringLength (100)]
        [Required]
        [Column("contact")]
        public string Contact { get; set; }

        // Ubicación
        [StringLength(200)]
        [Column("location")]
        public string Location { get; set; }

        // Fecha de registro
        [Column("registration_date")]
        public DateTime RegistrationDate { get; set; }

        // Para la relación con Paquete de viaje
        public virtual IEnumerable<TravelPackageEntity> TravelPackages {  get; set; }
    }
}
