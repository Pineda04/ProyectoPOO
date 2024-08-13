using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API.Database.Entities;

namespace ProyectoViajes.API.Database
{
    public class ProyectoViajesContext : DbContext
    {
        public ProyectoViajesContext(DbContextOptions options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<AgencyEntity> Agencies { get; set; }
        public DbSet<DestinationEntity> Destinations { get; set; }
        public DbSet<PointInterestEntity> PointsInterest { get; set; }
        public DbSet<TravelPackageEntity> TravelPackages { get; set; }
        public DbSet<ActivityEntity> Activities { get; set; }
        public DbSet<AssessmentEntity> Assessments { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ReservationEntity> Reservations { get; set; }
        public DbSet<PaymentEntity> Payments { get; set; }
    }
}