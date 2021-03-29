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
                if (retryForAvailability<3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<StudyRoomDbContextSeed>();
                    log.LogError(exception.Message);
                    await SeedAsync(roomContext,loggerFactory,retryForAvailability);
                }
            }
        }

        public static IEnumerable<Rooms> GetPreconfiguredRooms()
        {
            return new List<Rooms> { 
                new Rooms(){ SId= 006, Capacity= 6, Floor = 2, Location = "Library", Options= 0 },
                new Rooms(){ SId= 005, Capacity= 4, Floor = 1, Location = "SOC", Options= 1 }
            };
        }
    }
}
