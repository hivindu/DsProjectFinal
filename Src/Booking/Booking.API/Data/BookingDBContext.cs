using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Booking.API.Entities;

namespace Booking.API.Data
{
    public class BookingDBContext : DbContext
    {
        public BookingDBContext (DbContextOptions<BookingDBContext> options)
            : base(options)
        {
        }

        public DbSet<Booking.API.Entities.Book> Book { get; set; }
    }
}
