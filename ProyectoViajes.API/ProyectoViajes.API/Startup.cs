using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API.Database;
using ProyectoViajes.API.Helpers;
using ProyectoViajes.API.Services;
using ProyectoViajes.API.Services.Interfaces;

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

            // Add Custom Services
            services.AddTransient<IAgenciesService, AgenciesService>();
            services.AddTransient<IDestinationsService, DestinationsService>();
            services.AddTransient<IPointsInterestService, PointsInterestService>();
            services.AddTransient<ITravelPackagesService, TravelPackagesService>();
            services.AddTransient<IActivitiesService, ActivitiesService>();
            services.AddTransient<IAssessmentService, AssessmentService>();
            services.AddTransient<IReservationsService, ReservationsService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IPaymentService, PaymentService>();

            // Add AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

            // CORS Configuration
            services.AddCors(opt => 
            {
                var allowURLS = Configuration.GetSection("AllowURLS").Get<string[]>();
                
                opt.AddPolicy("CorsPolicy", builder => builder
                .WithOrigins(allowURLS)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });
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

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}