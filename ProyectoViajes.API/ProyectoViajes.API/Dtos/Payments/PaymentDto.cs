namespace ProyectoViajes.API.Dtos.Payments
{
    public class PaymentDto
    {
        public Guid Id { get; set; }

        public Guid ReservationId { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public string PaymentMethod { get; set; }

        public string Status { get; set; }
    }
}