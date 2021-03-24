using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyRoom.API.Data;
using StudyRoom.API.Model;

namespace StudyRoom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly StudyRoomDbContext _context;

        public RoomsController(StudyRoomDbContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rooms>>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rooms>> GetRooms(int id)
        {
            var rooms = await _context.Rooms.FindAsync(id);

            if (rooms == null)
            {
                return NotFound();
            }

            return rooms;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRooms(int id, Rooms rooms)
        {
            if (id != rooms.SId)
            {
                return BadRequest();
            }

            _context.Entry(rooms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomsExists(id))
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
        public async Task<ActionResult<Rooms>> PostRooms(Rooms rooms)
        {
            _context.Rooms.Add(rooms);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRooms", new { id = rooms.SId }, rooms);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rooms>> DeleteRooms(int id)
        {
            var rooms = await _context.Rooms.FindAsync(id);
            if (rooms == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(rooms);
            await _context.SaveChangesAsync();

            return rooms;
        }

        private bool RoomsExists(int id)
        {
            return _context.Rooms.Any(e => e.SId == id);
        }
    }
}
