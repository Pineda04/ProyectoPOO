using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoViajes.API.Database.Entities
{
    [Table("user", Schema = "dbo")]
    public class UserEntity
    {
        // Id
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        // Nombre
        [Required]
        [StringLength(100)]
        [Column("name")]
        public string Name { get; set; }

        // Correo electrónico
        [Required]
        [StringLength(50)]
        [Column("email")]
        public string Email { get; set; }

        // Contraseña
        [Required]
        [StringLength(50)]
        [Column("password")]
        public string Password { get; set; }

        // Fecha de registro
        [Column("registration_date")]
        public DateTime RegistrationDate { get; set; }

        // Relación con Reservas
        public virtual IEnumerable<ReservationEntity> Reservations { get; set; }

        // Relación con Valoraciones
        public virtual IEnumerable<AssessmentEntity> Assessments { get; set; }
    }
}