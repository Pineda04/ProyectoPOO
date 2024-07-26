using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoViajes.API.Database.Entities
{
    [Table("reservations", Schema = "dbo")]
    public class ReservationEntity
    {
        // Id

        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        // Usuario Id
        [Column("user_id")]
        public Guid UserId { get; set; }

        // Paquete Id
        [Column("package_id")]
        [Required]
        public Guid PackageId { get; set; }
        [ForeignKey(nameof(PackageId))]
        public virtual TravelPackageEntity TravelPackage { get; set; }

        // Fehca de reservación
        [Display(Name = "Fecha de Reserva")]
        [Column("reservation_date")]
        [Required(ErrorMessage = "La {0} es requerida")]
        public DateTime ReservationDate { get; set; }

        // Estado

        [Display(Name = "Estado")]
        [Column("status")]
        [Required(ErrorMessage = "El {0} es requerido")]
        public string Status { get; set; }

        // Total pagado

        [Display(Name = "Total Pagado")]
        [Column("total_paid")]
        [Required(ErrorMessage = "El {0} es requerido")]
        public decimal TotalPaid { get; set; }

        // Relación con pagos

        public virtual IEnumerable<PaymentEntity> Payments { get; set; }

    }
}
