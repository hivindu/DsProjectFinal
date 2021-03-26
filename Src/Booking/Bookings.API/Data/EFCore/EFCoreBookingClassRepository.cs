using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookings.API.Models;


namespace Bookings.API.Data.EFCore
{
    public class EFCoreBookingClassRepository : EfCoreRepository<BookingClass, BookingsAPIContext>
    {
        public EFCoreBookingClassRepository(BookingsAPIContext context) : base(context)
        {

        }
        // We can add new methods specific to the movie repository here in the future
    }
}
