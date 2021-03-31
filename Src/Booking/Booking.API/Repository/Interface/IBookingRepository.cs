using Booking.API.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Repository.Interface
{
    public interface IBookingRepository
    {
        Task<ActionResult<IEnumerable<Book>>> GetBookings();

        Task<IEnumerable<Book>> GetBooking(int Id);

        Task<IEnumerable<Book>> GetBookingByUser(int UId);

        Task<IEnumerable<Book>> GetBookingByRoom(int SId);

        Task Create(Book reservation);

        Task<bool> Update(Book reservation);

        Task<bool> Delete(int Id);
    }
}
