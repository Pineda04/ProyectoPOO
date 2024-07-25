using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API.Dtos.Reservations;

namespace ProyectoViajes.API.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ReservationDto> Reservations { get; set; }
       // public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
