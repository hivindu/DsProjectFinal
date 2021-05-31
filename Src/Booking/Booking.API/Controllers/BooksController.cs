using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Booking.API.Data;
using Booking.API.Entities;
using Booking.API.Repository.Interface;
using System.Net;

namespace Booking.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookingDBContext _context;
        private readonly IBookingRepository _repository;

        public BooksController(IBookingRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Books
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetBook()
        {
            return await _repository.GetBookings();
        }

        // GET: api/Books/5
        [HttpGet("{id}",Name ="GetRoom")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _repository.GetBooking(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet("[action]/{SID}")]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetBookingsByRoom(int SID)
        {
            var bookings = await _repository.GetBookingByRoom(SID);

            if (bookings == null)
            {
                return NotFound();
            }

            return Ok(bookings);
        }


        [HttpGet("[action]/{UID}")]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetBookingsByUser(int UID)
        {
            var bookings = await _repository.GetBookingByUser(UID);

            if (bookings == null)
            {
                return NotFound();
            }

            return Ok(bookings);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBooking([FromBody] Book book)
        {
            await _repository.Create(book);
             
            return CreatedAtAction("GetBook", new { id = book.BId }, book);
        }

        
        [HttpPut]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBooking([FromBody] Book book)
        {
            return Ok(await _repository.Update(book));
        }

       
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Book>> DeleteBooking(int id)
        {
            return Ok(await _repository.Delete(id));
        }

        
    }
}
