using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bookings.API.Models;

namespace Bookings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingClassesController : ControllerBase
    {
        private readonly BookingsAPIContext _context;

        public BookingClassesController(BookingsAPIContext context)
        {
            _context = context;
        }

        // GET: api/BookingClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingClass>>> GetBookingClass()
        {
            return await _context.BookingClass.ToListAsync();
        }

        // GET: api/BookingClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingClass>> GetBookingClass(int id)
        {
            var bookingClass = await _context.BookingClass.FindAsync(id);

            if (bookingClass == null)
            {
                return NotFound();
            }

            return bookingClass;
        }

        // PUT: api/BookingClasses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingClass(int id, BookingClass bookingClass)
        {
            if (id != bookingClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookingClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingClassExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookingClasses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookingClass>> PostBookingClass(BookingClass bookingClass)
        {
            _context.BookingClass.Add(bookingClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingClass", new { id = bookingClass.Id }, bookingClass);
        }

        // DELETE: api/BookingClasses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookingClass>> DeleteBookingClass(int id)
        {
            var bookingClass = await _context.BookingClass.FindAsync(id);
            if (bookingClass == null)
            {
                return NotFound();
            }

            _context.BookingClass.Remove(bookingClass);
            await _context.SaveChangesAsync();

            return bookingClass;
        }

        private bool BookingClassExists(int id)
        {
            return _context.BookingClass.Any(e => e.Id == id);
        }
    }
}
