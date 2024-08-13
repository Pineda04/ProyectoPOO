using ProyectoViajes.API.Dtos.Activities;
using ProyectoViajes.API.Dtos.Assessments;
using ProyectoViajes.API.Dtos.Reservations;

namespace ProyectoViajes.API.Dtos.TravelPackages
{
    public class TravelPackageDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Duration { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<ActivityDto> Activities { get; set; }

        public Guid AgencyId { get; set; }

        public Guid DestinationId { get; set; }

        public List<ReservationDto> Reservations { get; set; }

        public List<AssessmentDto> Assessments { get; set; }
    }
}