using System.ComponentModel.DataAnnotations;

namespace ProyectoViajes.API.Dtos.TravelPackages
{
    public class TravelPackageCreateDto
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(100, ErrorMessage = "El {0} debe tener menos de {1} caracteres.")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(500, ErrorMessage = "La {0} debe tener menos de {1} caracteres.")]
        public string Description { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public double Price { get; set; }

        [Display(Name = "Duración")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public int Duration { get; set; }

        [Display(Name = "Fecha de Inicio")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Fecha de Fin")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Agencia")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public Guid AgencyId { get; set; }

        [Display(Name = "Destino")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public Guid DestinationId { get; set; }
    }
}
