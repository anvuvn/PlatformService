using System.Collections.Generic;
using System.Linq;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly ApplicationDBContext dbContext;

        public PlatformRepo(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;    
        }

        public void CreatePlatform(Platform platform)
        { 
            if (platform == null)
            {
                throw new System.ArgumentNullException(nameof(platform));
            }
            dbContext.Platforms.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return dbContext.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        { 
            return dbContext.Platforms.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            // SaveChanges() returns the number of rows affected
            return dbContext.SaveChanges() >= 0;
        }
    }
}