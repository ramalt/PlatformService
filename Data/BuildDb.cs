using PlatformService.Models;

namespace PlatformService.Data;

public class BuildDb
{
    public static void PreparePopulation(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

        SeedData(context: serviceScope.ServiceProvider.GetService<AppDbContext>());

    }
    private static void SeedData(AppDbContext context)
    {
        if (!context.Platforms.Any())
        {
            Console.WriteLine("--> 🍃 - Seeding Data...");

            context.Platforms.AddRange(
                new Platform { Name = "Dotnet", Publisher = "Microsoft", Cost = "Free" },
                new Platform { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                new Platform { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
            );

            context.SaveChanges();


        }
        else
        {
            Console.WriteLine("--> ⛑️ - Data already does exist.");
        }
    }
}
