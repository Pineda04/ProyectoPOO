using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Dtos.Reservations;

namespace ProyectoViajes.API.Database
{
    public class ApplicationDbContext : DbContext
    {
       
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

           
            public DbSet<PaymentEntity> Payments { get; set; }

            
            public DbSet<ReservationEntity> Reservations { get; set; }
            
             
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<ReservationEntity>()
               .HasMany(r => r.Payments)
               .WithOne(p => p.Reservation)
               .HasForeignKey(p => p.ReservationId);

        }
        }
    }

