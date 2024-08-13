using System.ComponentModel.DataAnnotations;

namespace ProyectoViajes.API.Dtos.Payments
{
    public class PaymentCreateDto
    {
        // Reservación id
        [Display(Name = "id de la reservacion")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public Guid ReservationId { get; set; }

        // Monto
        [Display(Name = "monto")]
        [Required(ErrorMessage = "El {0} de pago es requerido.")]
        public decimal Amount { get; set; }

        // Fecha de pago
        [Display(Name = "fecha de pago")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public DateTime PaymentDate { get; set; }

        // Metodo de pago
        [Display(Name = "metodo de pago")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public string PaymentMethod { get; set; }

        // Estado del pago
        [Display(Name = "estado de pago")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public string Status { get; set; }
    }
}