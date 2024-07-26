using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API.Database;
using ProyectoViajes.API.Services.Interfaces;
using ProyectoViajes.API.Services;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Helpers;
using AutoMapper;

namespace ProyectoViajes.API
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Add DbContext
            services.AddDbContext<ProyectoViajesContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add servicios de Agency
            services.AddTransient<IAgenciesService, AgenciesService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IDestinationsService, DestinationsService>();
            services.AddTransient<IPointsInterestService, PointsInterestService>();
            services.AddTransient<ITravelPackagesService, TravelPackagesService>();
            services.AddTransient<IActivitiesService, ActivitiesService>();
            services.AddTransient<IAssessmentService, AssessmentService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IReservationService, ReservationService>();

            // Add AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }

        private Action<IMapperConfigurationExpression> nameof(AutoMapperProfile autoMapperProfile)
        {
            throw new NotImplementedException();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
