using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NUsers.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUsers.API.Data
{
    public class NUsersDBContextSeed
    {
        public static async Task SeedAsync(NUsersDBContext NUsercontext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                NUsercontext.Database.Migrate();

                if (!NUsercontext.Users.Any())
                {
                    NUsercontext.Users.AddRange(GetPreconfiguredAdmin());
                    await NUsercontext.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 50)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<NUsersDBContextSeed>();
                    log.LogError(exception.Message);
                    System.Threading.Thread.Sleep(2000);
                    await SeedAsync(NUsercontext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }
        public static IEnumerable<UserData> GetPreconfiguredAdmin()
        {
            return new List<UserData> {
                new UserData(){ UId = 005, F_name= "Hivindu", L_name = "Amaradewa", Contact = 0715344131, Address= "Colombo", Batch = "182", Degree = "Software Engineering", Password = "Dasuni", Type = 0 }

            };
        }
    }
}
