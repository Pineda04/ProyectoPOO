using ProyectoViajes.API.Dtos.TravelPackages;

namespace ProyectoViajes.API.Dtos.Activities
{
    public class ActivityDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid TravelPackageId { get; set; }

        public TravelPackageDto TravelPackage { get; set; }
    }
}
