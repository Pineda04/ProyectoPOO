using System.ComponentModel.DataAnnotations;

namespace ProyectoViajes.API.Database.Entities
{
    public class ReservationEntity
    {

        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Usuario ID")]
        [Required(ErrorMessage = "El {0} es requerido")]
        public Guid UserId { get; set; }

        [Display(Name = "Paquete ID")]
        [Required(ErrorMessage = "El {0} es requerido")]
        public Guid PackageId { get; set; }

        [Display(Name = "Fecha de Reserva")]
        [Required(ErrorMessage = "La {0} es requerida")]
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El {0} es requerido")]
        [StringLength(50)]
        public string Status { get; set; }

        [Display(Name = "Total Pagado")]
        [Required(ErrorMessage = "El {0} es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El {0} debe ser mayor a 0")]
        public decimal TotalPaid { get; set; }

    }
}
