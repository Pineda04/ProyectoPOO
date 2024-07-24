using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Database
{
    public class ProyectoViajesContext : DbContext
    {
        private readonly IAuthService _authService;

        public ProyectoViajesContext(DbContextOptions options, IAuthService authService) : base(options)
        {
            this._authService = authService;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                var entity = entry.Entity;

                if (entity != null)
                {
                    if(entry.State == EntityState.Added)
                    {

                    }
                    else
                    {

                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<AgencyEntity> Agencies { get; set; }
        public DbSet<DestinationEntity> Destination { get; set; }
        public DbSet<TravelPackageEntity> TravelPackages { get; set; }
    }
}
