using Base.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Base.API.Config
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, ConfigurationManager configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddControllers();
        }

        public static void UseApiConfiguration(this WebApplication app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
