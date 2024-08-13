using System.ComponentModel.DataAnnotations;

namespace ProyectoViajes.API.Dtos.Reservations
{
    public class ReservationCreateDto
    {
        // Usuario id
        [Display(Name = "id del usuario")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public Guid UserId { get; set; }

        // Paquete de viaje Id
        [Display(Name = "id del paquete de viaje")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public Guid TravelPackageId { get; set; }
        
        // Fecha de reserva
        [Display(Name = "fecha de reservacion")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public DateTime ReservationDate { get; set; }

        // Cantidad de personas
        [Display(Name = "cantidad de personas")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public int NumberPeople { get; set; }

        // Estado de la reserva
        [Display(Name = "estado de la reservacion")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public bool StatusReservation { get; set; }
    }
}