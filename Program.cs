using AnasProject.Models;
using AnasProject.Repos.CircularGeofenceRepository;
using AnasProject.Repos.DriverRepository;
using AnasProject.Repos.GeofenceRepository;
using AnasProject.Repos.PolygonGeofenceRepository;
using AnasProject.Repos.RectangularGeofenceReopsitory;
using AnasProject.Repos.RouteHistoryRepository;
using AnasProject.Repos.VehicleInformationRepository;
using AnasProject.Repos.VehicleRepository;
using Microsoft.EntityFrameworkCore;

namespace AnasProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            builder.Services.AddScoped<IDriverRepo, DriverRepo>();
            builder.Services.AddScoped<IVehicleRepo, VehicleRepo>();
            builder.Services.AddScoped<IVehicleInformationRepo, VehicleInformationRepo>();
            builder.Services.AddScoped<IRouteHistoryRepo, RouteHistoryRepo>();
            builder.Services.AddScoped<IGeofenceRepo, GeofenceRepo>();
            builder.Services.AddScoped<ICircularGeofenceRepo, CircularGeofenceRepo>();
            builder.Services.AddScoped<IRectangularGeofenceRepo, RectangularGeofenceRepo>();
            builder.Services.AddScoped<IPolygonGeofenceRepo, PolygonGeofenceRepo>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
