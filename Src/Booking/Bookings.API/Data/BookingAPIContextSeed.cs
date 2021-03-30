using Bookings.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookings.API.Data.EFCore
{
    public class BookingAPIContextSeed
    {
        public static async Task SeedAsync(BookingsAPIContext roomContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                roomContext.Database.Migrate();

                if (!roomContext.Rooms.Any())
                {
                    roomContext.Rooms.AddRange(GetPreconfiguredRooms());
                    await roomContext.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 50)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<StudyRoomDbContextSeed>();
                    log.LogError(exception.Message);
                    System.Threading.Thread.Sleep(2000);
                    await SeedAsync(roomContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }
    }
}
