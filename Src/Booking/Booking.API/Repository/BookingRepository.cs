using Booking.API.Data;
using Booking.API.Entities;
using Booking.API.Repository.Interface;
using Microsoft.AspNetCore.Http;
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

        public async Task<ActionResult<IEnumerable<Book>>> GetBookings()
        {
            string query = "EXEC SelAllBookings";
            return await _context.Book.FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooking(int Id)
        {
            string query = "EXEC SelBookingById @id=" + Id + "";
            return await _context.Book.FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBookingByRoom(int SId)
        {
            string query = "EXEC SelAllBookingsByRoom @id=" + SId + "";
            return await _context.Book.FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBookingByUser(int UId)
        {
            string query = "EXEC SelAllBookingsByUser @id=" + UId + "";
            return await _context.Book.FromSqlRaw(query).ToListAsync();
        }

        public async Task Create(Book reservation)
        {
            DateTime FDate = reservation.FromTime;
            DateTime TDate = reservation.ReservationDate;
            int StudentCount = reservation.StudentCount;
            DateTime rdate = reservation.ReservationDate;
            int uid = reservation.UserId;
            int sid = reservation.SID;
            string purpose = reservation.Purpose;
            var rest = _context.Database.ExecuteSqlCommand("EXEC InsBooking  @count ='" + StudentCount + "', @ftime='" + FDate + "',@ttime='" + TDate + "',@rdate='" + rdate + "',@uid='" + uid + "',@sid='"+ sid + "',@purpose='"+ purpose + "'");

        }

        public async Task<bool> Update(Book reservation)
        {
            
            var res = _context.Database.ExecuteSqlCommand("EXEC UpdBook @bid='" + reservation.BId + "',@Count='" + reservation.StudentCount + "',@Ftime='" + reservation.FromTime + "',@Ttime='" + reservation.ToTime + "',@Date='" + reservation.ReservationDate + "',@Uid='"+reservation.UserId+ "',@Sid='"+reservation.SID+ "',@Purpose='"+reservation.Purpose+"'");

            return Convert.ToBoolean(res);
        }

        public async Task<bool> Delete(int Id)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC DelBooking @sid='" + Id + "'");

            return Convert.ToBoolean(res);
        }

    }
}
