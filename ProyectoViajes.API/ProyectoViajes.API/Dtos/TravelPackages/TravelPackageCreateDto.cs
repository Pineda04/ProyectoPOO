using System.ComponentModel.DataAnnotations;

namespace ProyectoViajes.API.Dtos.TravelPackages
{
    public class TravelPackageCreateDto
    {
        // Nombre
        [Display(Name = "nombre")]
        [StringLength(100, ErrorMessage = "El {0} del paquete de viaje debe tener menos de {1} caracteres.")]
        [Required(ErrorMessage = "El {0} del paquete de viaje es requerido.")]
        public string Name { get; set; }

        // Descripción
        [Display(Name = "descripcion")]
        [StringLength(500, ErrorMessage = "La {0} del paquete de viaje debe tener menos de {1} caracteres.")]
        public string Description { get; set; }

        // Precio
        [Display(Name = "precio")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public decimal Price { get; set; }

        // Duración
        [Display(Name = "duracion")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public int Duration { get; set; }

        // Fecha de inicio
        [Display(Name = "fecha de inicio")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public DateTime StartDate { get; set; }

        // Fecha de fin
        [Display(Name = "fecha de fin")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public DateTime EndDate { get; set; }

        // Agencia Id
        [Display(Name = "id de la agencia")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public Guid AgencyId { get; set; }

        // Destino Id
        [Display(Name = "id del destino")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public Guid DestinationId { get; set; }

        // Imagen
        [Display(Name = "url de la imagen")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public string ImageUrl { get; set; }
    }
}