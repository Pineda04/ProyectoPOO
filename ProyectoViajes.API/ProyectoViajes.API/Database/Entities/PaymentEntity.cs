using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoViajes.API.Database.Entities
{


    [Table("payments", Schema = "dbo")]
    public class PaymentEntity
    {

        [Key]
        public Guid PaymentId { get; set; }

        [Required]
        public Guid ReservationId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }

}

