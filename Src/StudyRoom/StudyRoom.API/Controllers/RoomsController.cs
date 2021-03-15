using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudyRoom.API.Data;
using StudyRoom.API.Entities;
using StudyRoom.API.Repository.Interface;

namespace StudyRoom.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IStuddyRoomRepository _repository;
        private readonly ILogger<RoomsController> _logger;

        public RoomsController(IStuddyRoomRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET: api/Rooms
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Rooms>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Rooms>>> GetRoom()
        {
            var result = await _repository.GetRooms();
            return Ok(result);
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rooms>> GetRoom(int id)
        {
            var room = await _context.Room.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Rooms room)
        {
            if (id != room.SId)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
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

        // POST: api/Rooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Rooms>> PostRoom(Rooms room)
        {
            _context.Room.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = room.SId }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rooms>> DeleteRoom(int id)
        {
            var room = await _context.Room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Room.Remove(room);
            await _context.SaveChangesAsync();

            return room;
        }

        private bool RoomExists(int id)
        {
            return _context.Room.Any(e => e.SId == id);
        }
    }
}
