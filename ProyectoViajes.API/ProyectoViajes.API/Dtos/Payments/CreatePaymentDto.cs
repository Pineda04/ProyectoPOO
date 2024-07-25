using System.ComponentModel.DataAnnotations;

namespace ProyectoViajes.API.Dtos.Payments
{
    public class CreatePaymentDto
    {
        [Display(Name = "nombre")]
        [Required(ErrorMessage = "el {0} de la categoria es requerido")]
        public string Name { get; set; }

        [Display(Name = "Descripcion")]
        [MinLength(10, ErrorMessage = "la {0} debe tener almenos {1} caracteres")]
        public string Description { get; set; }
    }
}
