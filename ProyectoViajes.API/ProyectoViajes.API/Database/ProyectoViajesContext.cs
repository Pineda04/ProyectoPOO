﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<DestinationEntity> Destinations { get; set; }
        public DbSet<TravelPackageEntity> TravelPackages { get; set; }
        public DbSet<ActivityEntity> Activities { get; set; }
        public DbSet<PointInterestEntity> PoinstInterest { get; set; }
        public DbSet<PaymentEntity> Payments { get; set; }
        public DbSet<ReservationEntity> Reservations { get; set; }
        public DbSet<AssessmentEntity> Assessments { get; set; }
        public DbSet<PointInterestEntity> PointsInterest { get; set; }
    }
}
