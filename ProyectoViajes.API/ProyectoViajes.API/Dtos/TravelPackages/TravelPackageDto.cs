using ProyectoViajes.API.Dtos.Activities;
using ProyectoViajes.API.Dtos.Agencies;
using ProyectoViajes.API.Dtos.Destinations;

namespace ProyectoViajes.API.Dtos.TravelPackages
{
    public class TravelPackageDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Duration { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid AgencyId { get; set; }

        public Guid DestinationId { get; set; }

        public AgencyDto Agency { get; set; }

        public DestinationDto Destination { get; set; }

        public List<ActivityDto> Activities { get; set; }
    }
}
