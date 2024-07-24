using System.ComponentModel.DataAnnotations;

namespace ProyectoViajes.API.Dtos.Agencies
{
    public class AgencyCreateDto
    {
        // Nombre
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} de la agencia es requerido.")]
        public string Name { get; set; }

        // Descripción
        public string Description { get; set; }

        // Contacto
        [Display(Name = "Contacto")]
        [Required(ErrorMessage = "El {0} de la agencia es requerido.")]
        public string Contact { get; set; }

        // Ubicación
        public string Location { get; set; }

        // Fecha de registro
        public DateTime RegistrationDate { get; set; }
    }
}
