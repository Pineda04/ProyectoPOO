namespace ProyectoViajes.API.Dtos.Assessments
{
    public class CreateAssessmentDto
    {
        public Guid UserId { get; set; }
        public Guid PackageId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
