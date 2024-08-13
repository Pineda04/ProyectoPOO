using ProyectoViajes.API.Dtos.PointsInterest;

namespace ProyectoViajes.API.Dtos.Destinations
{
    public class DestinationDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime RegistrationDate { get; set; }

        public List<PointInterestDto> PointsInterest { get; set; }
    }
}