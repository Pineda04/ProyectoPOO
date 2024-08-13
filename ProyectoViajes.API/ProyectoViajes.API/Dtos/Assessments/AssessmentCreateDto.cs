using System.ComponentModel.DataAnnotations;

namespace ProyectoViajes.API.Dtos.Assessments
{
    public class AssessmentCreateDto
    {
        // Usuario Id
        [Display(Name = "id del usuario")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public Guid UserId { get; set; }

        // Paquete de viajes Id
        [Display(Name = "id del paquete de viajes")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public Guid TravelPackageId { get; set; }

        // Puntuación
        [Display(Name = "puntuacion")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        [Range(1,5, ErrorMessage = "La {0} no se puede exceder.")]
        public int Rating { get; set; }

        // Comentarios
        [Display(Name = "comentario")]
        [StringLength(500, ErrorMessage = "El {0} debe ser menor a {1} caracteres.")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public string Comment { get; set; }
    }
}