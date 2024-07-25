using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoViajes.API.Database.Entities
{
    [Table("reservations", Schema = "dbo")]
    public class ReservationEntity
    {

        [Key]
        public Guid ReservationId { get; set; }

        public Guid UserId { get; set; }
        public Guid PackageId { get; set; }

        [Display(Name = "Fecha de Reserva")]
        [Required(ErrorMessage = "La {0} es requerida")]
        public DateTime ReservationDate { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El {0} es requerido")]
        public string Status { get; set; }

        [Display(Name = "Total Pagado")]
        [Required(ErrorMessage = "El {0} es requerido")]
        public decimal TotalPaid { get; set; }

        public virtual ICollection<PaymentEntity> Payments { get; set; }

    }
}
