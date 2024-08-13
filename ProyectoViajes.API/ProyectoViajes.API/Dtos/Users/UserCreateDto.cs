using System.ComponentModel.DataAnnotations;

namespace ProyectoViajes.API.Dtos.Users
{
    public class UserCreateDto
    {
        // Nombre
        [Display(Name = "nombre")]
        [StringLength(100, ErrorMessage = "El {0} del usuario tener menos de {1} caracteres.")]
        [Required(ErrorMessage = "El {0} del usuario es requerido.")]
        public string Name { get; set; }

        // Correo electrónico
        [Display(Name = "correo electronico")]
        [StringLength(50, ErrorMessage = "El {0} del usuario tener menos de {1} caracteres.")]
        [Required(ErrorMessage = "El {0} del usuario es requerido.")]
        public string Email { get; set; }

        // Contraseña
        [Display(Name = "contraseña")]
        [StringLength(50, ErrorMessage = "La {0} del usuario tener menos de {1} caracteres.")]
        [Required(ErrorMessage = "La {0} del usuario es requerido.")]
        public string Password { get; set; }

        // Rol
        [Display(Name = "rol")]
        [StringLength(20, ErrorMessage = "El {0} del usuario tener menos de {1} caracteres.")]
        [Required(ErrorMessage = "El {0} del usuario es requerido.")]
        public string Rol { get; set; }
    }
}