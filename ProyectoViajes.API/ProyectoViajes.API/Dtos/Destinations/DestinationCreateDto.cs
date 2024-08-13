using System.ComponentModel.DataAnnotations;

namespace ProyectoViajes.API.Dtos.Destinations
{
    public class DestinationCreateDto
    {   
        // Nombre
        [Display(Name = "nombre")]
        [StringLength(100, ErrorMessage = "El {0} del destino debe tener menos de {1} caracteres.")]
        [Required(ErrorMessage = "El {0} del destino es requerido.")]
        public string Name { get; set; }

        // Descripción
        [Display(Name = "descripcion")]
        [StringLength(500, ErrorMessage = "La {0} del destino debe tener menos de {1} caracteres.")]
        public string Description { get; set; }

        // Ubicación
        [Display(Name = "ubicacion")]
        [StringLength(100, ErrorMessage = "La {0} del destino debe tener menos de {1} caracteres.")]
        public string Location { get; set; }
    }
}