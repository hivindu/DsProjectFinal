using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bookings.API.Models
{
    public class BookingsAPIContext : DbContext
    {
        public BookingsAPIContext (DbContextOptions<BookingsAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Bookings.API.Models.BookingClass> BookingClass { get; set; }
    }
}
