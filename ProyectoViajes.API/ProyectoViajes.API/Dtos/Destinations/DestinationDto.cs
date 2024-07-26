using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Dtos.PointsInterest;
using ProyectoViajes.API.Dtos.TravelPackages;

namespace ProyectoViajes.API.Dtos.Destinations
{
    public class DestinationDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public List<PointInterestDto> PointsInterest { get; set; }

        public List<TravelPackageDto> TravelPackages { get; set; }
    }
}
