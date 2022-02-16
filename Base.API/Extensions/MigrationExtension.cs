using Base.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Base.API.Extensions
{
    public static class MigrationExtension
    {
        public static void RunMigration(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DataContext>();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occored during migration");
                }
            }
        }
    }
}
