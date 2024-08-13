using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoViajes.API.Database.Entities
{
    [Table("reservation", Schema = "dbo")]
    public class ReservationEntity
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

        // Paquete de viaje Id
        [Required]
        [Column("travel_package_id")]
        public Guid TravelPackageId { get; set; }
        [ForeignKey(nameof(TravelPackageId))]
        public virtual TravelPackageEntity TravelPackage { get; set; }

        // Fecha de reserva
        [Required]
        [Column("reservation_date")]
        public DateTime ReservationDate { get; set; }

        // Cantidad de personas
        [Required]
        [Column("number_people")]
        public int NumberPeople { get; set; }

        // Estado de la reserva
        [Required]
        [Column("status_reservation")]
        public bool StatusReservation { get; set; }

        // Relación con pagos
        public virtual IEnumerable<PaymentEntity> Payments {get; set;}
    }
}