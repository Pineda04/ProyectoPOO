namespace ProyectoViajes.API.Dtos.Reservations
{
    public class ReservationDto
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }

        public Guid TravelPackageId { get; set; }

        public DateTime ReservationDate { get; set; }

        public int NumberPeople { get; set; }

        public bool StatusReservation { get; set; }
    }
}