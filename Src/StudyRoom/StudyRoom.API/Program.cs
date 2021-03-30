using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StudyRoom.API.Data;

namespace StudyRoom.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateAndSeedDatabase(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static async void CreateAndSeedDatabase(IHost host)
        {
            using (var scope  = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var roomContext = services.GetRequiredService<StudyRoomDbContext>();
                    await StudyRoomDbContextSeed.SeedAsync(roomContext,loggerFactory);
                }
                catch (Exception exception)
                {

                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(exception.Message);
                }
            }
        }
    }
}
