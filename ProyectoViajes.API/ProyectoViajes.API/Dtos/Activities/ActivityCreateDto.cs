using System.ComponentModel.DataAnnotations;

namespace ProyectoViajes.API.Dtos.Activities
{
    public class ActivityCreateDto
    {
        // Nombre
        [Display(Name = "nombre")]
        [StringLength(100, ErrorMessage = "El {0} de la actividad debe tener menos de {1} caracteres.")]
        [Required(ErrorMessage = "El {0} de la actividad de requerido.")]
        public string Name { get; set; }

        // Descripción
        [Display(Name = "descripcion")]
        [StringLength(500, ErrorMessage = "La {0} de la actividad debe tener menos de {1} caracteres.")]
        public string Description { get; set; }

        // Paquete de viaje Id
        [Display(Name = "id del paquete de viaje")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public Guid TravelPackageId { get; set; }
    }
}