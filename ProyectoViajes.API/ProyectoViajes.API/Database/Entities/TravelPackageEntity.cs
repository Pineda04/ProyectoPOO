using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ProyectoViajes.API.Database.Entities
{
    [Table("travel_package", Schema ="dbo")]
    public class TravelPackageEntity
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

        // Precio
        [Required]
        [Column("price")]
        public decimal Price { get; set; }

        // Duración (en dias)
        [Required]
        [Column("duration")]
        public int Duration { get; set; }

        // Fecha de inicio
        [Required]
        [Column("start_date")]
        public DateTime StartDate { get; set; }

        // Fecha de fin
        [Required]
        [Column("end_date")]
        public DateTime EndDate { get; set; }

        // Actividades
        public virtual IEnumerable<ActivityEntity> Activities { get; set; }

        // Agencia Id
        [Required]
        [Column("agency_id")]
        public Guid AgencyId { get; set; }
        [ForeignKey(nameof(AgencyId))]
        public AgencyEntity Agency { get; set; }

        // Destino Id
        [Required]
        [Column("destination_id")]
        public Guid DestinationId { get; set; }
        [ForeignKey(nameof(DestinationId))]
        public DestinationEntity Destination { get; set; }

        // Imagen
        [Required]
        [Column("image_url")]
        public string ImageUrl { get; set; }

        // Reserva
        public virtual IEnumerable<ReservationEntity> Reservations { get; set; }

        // Valoración
        public virtual IEnumerable<AssessmentEntity> Assessments { get; set; }
    }
}