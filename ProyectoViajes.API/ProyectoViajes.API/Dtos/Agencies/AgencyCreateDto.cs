using System.ComponentModel.DataAnnotations;

namespace ProyectoViajes.API.Dtos.Agencies
{
    public class AgencyCreateDto
    {
        // Nombre 
        [Display(Name = "nombre")]
        [Required(ErrorMessage = "El {0} de la agencia es requerido.")]
        public string Name { get; set; }

        // Descripción
        [Display(Name = "descripcion")]
        [Required(ErrorMessage = "La {0} de la agencia es requerida.")]
        [StringLength(500, ErrorMessage = "El {0} debe tener menos de {1} caracteres.")]
        public string Description { get; set; }

        // Contacto
        [Display(Name = "contacto")]
        [Required(ErrorMessage = "La dirección de {0} de la agencia es requerida.")]
        [StringLength(50, ErrorMessage = "El {0} debe tener menos de {1} caracteres.")]
        public string Contact { get; set; }

        // Ubicación
        [Display(Name = "ubicacion")]
        [Required(ErrorMessage = "La {0} de la agencia es requerida.")]
        [StringLength(100, ErrorMessage = "El {0} debe tener menos de {1} caracteres.")]
        public string Location { get; set; }
    }
}