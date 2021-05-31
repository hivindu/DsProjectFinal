using Booking.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Data
{
    public class BookingDBContextSeed
    {
        public static async Task SeedAsync(BookingDBContext bookingContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                bookingContext.Database.Migrate();

                if (!bookingContext.Book.Any())
                {
                    bookingContext.Book.AddRange(GetPreconfiguredBookings());
                    await bookingContext.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 50)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<BookingDBContextSeed>();
                    log.LogError(exception.Message);
                    System.Threading.Thread.Sleep(2000);
                    await SeedAsync(bookingContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        public static IEnumerable<Book> GetPreconfiguredBookings()
        {
            string dt = Convert.ToString(DateTime.Now.Date);
            return new List<Book> {
                new Book(){ ReservationDate= dt, StudentCount=6, SID=6, Purpose="DS Corsework", UserId=10026948,Slot = 0 }
            };
        }
    }
}
