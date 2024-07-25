using System.ComponentModel.DataAnnotations;

namespace ProyectoViajes.API.Dtos.Destinations
{
    public class DestinationCreateDto
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(100, ErrorMessage = "El {0} debe tener menos de {1} caracteres.")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(500, ErrorMessage = "La {0} debe tener menos de {1} caracteres.")]
        public string Description { get; set; }

        [Display(Name = "Ubicación")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        [StringLength(200, ErrorMessage = "La {0} debe tener menos de {1} caracteres.")]
        public string Location { get; set; }
    }
}
