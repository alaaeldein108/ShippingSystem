using Data.Context;
using Data.Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repositories;
using Services.Setting;

namespace ShippingProject.Extensions
{
    public static class ApplySeeding
    {
        public static async Task ApplySeedingAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger<AppDbContext>();
                var settings = services.GetRequiredService<IOptions<Setting>>();
                var context = services.GetRequiredService<AppDbContext>();
                if (settings.Value.AutoMigrateDatabase)
                {
                    context.Database.Migrate();
                }

                try
                {
                    var userManager = services.GetRequiredService<UserManager<AppUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
                    logger.LogInformation("Applying migrations...");

                    logger.LogInformation("Seeding users...");
                    await AddressContextSeed.SeedAsync(context, loggerFactory);
                    await AddIdentityContextSeed.SeedUserAsync(userManager, roleManager);
                    logger.LogInformation("User seeding completed.");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred during seeding");
                }
            }
        }
    }

}
