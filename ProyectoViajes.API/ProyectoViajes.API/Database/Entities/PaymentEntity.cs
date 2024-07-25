using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoViajes.API.Database.Entities
{


    [Table("payments", Schema = "dbo")]
    public class PaymentEntity
    {
 
        [Key]
        public Guid PaymentId { get; set; }
        [Display(Name = "Reserva ID")]
        [Required(ErrorMessage = "El {0} es requerido")]
        public Guid ReservationId { get; set; }  

        [Display(Name = "Monto")]
        [Required(ErrorMessage = "El {0} es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El {0} debe ser mayor a 0")]
        public decimal Amount { get; set; }

        [Display(Name = "Fecha de Pago")]
        [Required(ErrorMessage = "La {0} es requerida")]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }

        [Display(Name = "Método de Pago")]
        [Required(ErrorMessage = "El {0} es requerido")]
        [StringLength(50)]
        public string PaymentMethod { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El {0} es requerido")]
        [StringLength(50)]
        public string Status { get; set; }
    }

}

