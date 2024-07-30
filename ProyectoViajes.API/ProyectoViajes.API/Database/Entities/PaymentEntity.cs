using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoViajes.API.Database.Entities
{
    [Table("payments", Schema = "dbo")]
    public class PaymentEntity
    {
        // Id
        [Key]
        [Column("id")]
        public Guid PaymentId { get; set; }

        // Reserva id
        [Display(Name = "Reserva ID")]
        [Column("reservation_id")]
        [Required(ErrorMessage = "El {0} es requerido")]
        public Guid ReservationId { get; set; }
        [ForeignKey(nameof(ReservationId))]
        public virtual ReservationEntity Reservation { get; set; }

        // Monto
        [Display(Name = "Monto")]
        [Column("amount")]
        [Required(ErrorMessage = "El {0} es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El {0} debe ser mayor a 0")]
        public decimal Amount { get; set; }

        // Fecha de pago
        [Display(Name = "Fecha de Pago")]
        [Required(ErrorMessage = "La {0} es requerida")]
        [Column("payment_date")]
        public DateTime PaymentDate { get; set; }

        // Metodo de pago
        [Display(Name = "Método de Pago")]
        [Column("payment_method")]
        [Required(ErrorMessage = "El {0} es requerido")]
        [StringLength(50)]
        public string PaymentMethod { get; set; }

        // Estado
        [Display(Name = "Estado")]
        [Column("status")]
        [Required(ErrorMessage = "El {0} es requerido")]
        [StringLength(50)]
        public string Status { get; set; }
    }
}