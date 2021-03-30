using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bookings.API.Data.EFCore;
using Bookings.API.Models;

namespace Bookings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : MyMDBController<Booking, EFCoreBookingClassRepository>
    {
        public BookingController(EFCoreBookingClassRepository repository) : base(repository)
        {

        }
    }
}
