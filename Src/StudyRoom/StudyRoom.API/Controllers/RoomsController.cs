using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudyRoom.API.Model;
using StudyRoom.API.Repository.Interface;

namespace StudyRoom.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomsRepository _repository;

        public RoomsController(IRoomsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Rooms
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Rooms>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Rooms>>> GetRooms()
        {
            var Rooms = await _repository.GetRooms();

            return Ok(Rooms);
        }

        // GET: api/Rooms/5
        [HttpGet("{id}", Name = "GetRooms")]
        public async Task<ActionResult<Rooms>> GetRoom(int id)
        {
            var rooms = await _repository.GetRoom(id);

            if (rooms == null)
            {
                return NotFound();
            }

            return rooms;
        }

        [HttpGet("{option}")]
        [ProducesResponseType(typeof(IEnumerable<Rooms>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Rooms>> GetRoomByOption(int option)
        {
            var rooms = await _repository.GetRoomByOption(option);

            if (rooms == null)
            {
                return NotFound();
            }

            return Ok(rooms);
        }


        // POST: api/Rooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Rooms>> CreateRoom(Rooms rooms)
        {
            await _repository.Create(rooms);

            return CreatedAtAction("GetRooms", new { id = rooms.SId }, rooms);
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Rooms), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateRoom(int id, Rooms rooms)
        {
            if (id != rooms.SId)
            {
                return BadRequest();
            }

            return Ok(await _repository.Update(rooms));
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Rooms), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Rooms>> DeleteRoom(int id)
        {
            return Ok(await _repository.Delete(id));
        }
    }
}
