using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoViajes.API.Database.Entities
{
    [Table("payment", Schema = "dbo")]
    public class PaymentEntity
    {
        // Id
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        // Reserva Id
        [Required]
        [Column("reservation_id")]
        public Guid ReservationId { get; set; }
        [ForeignKey(nameof(ReservationId))]
        public virtual ReservationEntity Reservation { get; set; }

        // Monto
        [Required]
        [Column("amount")]
        public decimal Amount { get; set; }

        // Fecha de pago
        [Required]
        [Column("payment_date")]
        public DateTime PaymentDate { get; set; }

        // Metodo de pago
        [StringLength(50)]
        [Required]
        [Column("payment_method")]
        public string PaymentMethod { get; set; }

        // Estado
        [StringLength(20)]
        [Required]
        [Column("status")]
        public string Status { get; set; }
    }
}