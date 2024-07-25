using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API;
using ProyectoViajes.API.Database;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();