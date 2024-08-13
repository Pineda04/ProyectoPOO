namespace ProyectoViajes.API.Dtos.Agencies
{
    public class AgencyDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Contact { get; set; }

        public string Location { get; set; }
        
        public DateTime RegistrationDate { get; set; }
    }
}