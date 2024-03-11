using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PlatformService.Data
{
    public class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ApplicationDBContext>());
            }

        }

        private static void SeedData(ApplicationDBContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data...");
                context.Platforms.AddRange(
                    new Models.Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Models.Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Models.Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                );
                // SaveChanges 
                context.SaveChanges();
                
            }

            else{
                Console.WriteLine("--> Data is feeded already.");
            }

        }


      
    }
}