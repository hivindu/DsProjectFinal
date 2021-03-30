using AdminUser.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUser.API.Data
{
    public class AdminUserDBContextSeed
    {
        public static async Task SeedAsync(AdminUserDBContext AdminContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                AdminContext.Database.Migrate();

                if (!AdminContext.AdminUser.Any())
                {
                    AdminContext.AdminUser.AddRange(GetPreconfiguredAdmin());
                    await  AdminContext.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<AdminUserDBContextSeed>();
                    log.LogError(exception.Message);
                    await SeedAsync(AdminContext, loggerFactory, retryForAvailability);
                }
            }
        }
        public static IEnumerable<Admin> GetPreconfiguredAdmin()
        {
            return new List<Admin> {
                new Admin(){  }
            };
        }
    }
}
