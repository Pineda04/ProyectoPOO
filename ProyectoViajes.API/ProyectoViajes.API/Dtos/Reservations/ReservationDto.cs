namespace ProyectoViajes.API.Dtos.Reservations
{
    public class ReservationDto
    {  
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PackageId { get; set; }

        
        public DateTime ReservationDate { get; set; }
        public string Status { get; set; }
        public decimal TotalPaid { get; set; }
    }
}
