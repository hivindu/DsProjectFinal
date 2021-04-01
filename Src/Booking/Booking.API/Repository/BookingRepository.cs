using Booking.API.Data;
using Booking.API.Entities;
using Booking.API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDBContext _context;
        public BookingRepository(BookingDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooking(int Id)
        {
            string query = "";
            return await _context.Book.FromSqlRaw(query).ToListAsync();
        }

        public Task<IEnumerable<Book>> GetBookingByRoom(int SId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetBookingByUser(int UId)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<Book>>> GetBookings()
        {
            throw new NotImplementedException();
        }

        public Task Create(Book reservation)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Book reservation)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
