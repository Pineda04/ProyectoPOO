using System.ComponentModel.DataAnnotations;

namespace ProyectoViajes.API.Dtos.Payments
{
    public class CreatePaymentDto
    {
        public Guid ReservationId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }

        
    }
}
