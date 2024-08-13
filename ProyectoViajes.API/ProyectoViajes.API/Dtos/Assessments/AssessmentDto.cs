namespace ProyectoViajes.API.Dtos.Assessments
{
    public class AssessmentDto
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }

        public Guid TravelPackageId { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }

        public DateTime RatingDate { get; set; }
    }
}