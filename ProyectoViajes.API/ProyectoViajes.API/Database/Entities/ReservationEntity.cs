using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoViajes.API.Database.Entities
{
    [Table("reservations", Schema = "dbo")]
    public class ReservationEntity
    {

        [Key]
        public Guid ReservationId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid PackageId { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal TotalPaid { get; set; }

    }
}
