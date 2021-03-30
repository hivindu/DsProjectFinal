using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using StudyRoom.API.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StudyRoom.API.Data
{
    public class StudyRoomDbContextSeed
    {
        public static async Task SeedAsync(StudyRoomDbContext roomContext,ILoggerFactory loggerFactory,int? retry =0)
        {
            int retryForAvailability = retry.Value;

            try {
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
                throw;            }
        }

        public static IEnumerable<Rooms> GetPreconfiguredRooms()
        {
            return new List<Rooms> { 
                new Rooms(){ Capacity= 6, Floor = 2, Location = "Library", Options= 0 }
            };
        }
    }
}
