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
        public async Task<ActionResult<IEnumerable<Rooms>>> GetRooms()
        {
            var result = await _repository.GetRooms();
            return Ok(result);
        }

        // GET: api/Room/5
        [HttpGet("{id}", Name = "GetRoom")]
        public async Task<ActionResult<Rooms>> GetRoom(int id)
        {
            var room = await _repository.GetRoom(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // GET: api/Room/1
        [HttpGet("{option}")]
        public async Task<ActionResult<Rooms>> GetRoomByOption(int option)
        {
            var room = await _repository.GetRoomByOption(option);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        [HttpGet("{capacity}")]
        public async Task<ActionResult<Rooms>> GetRoomByCapacity(int capacity)
        {
            var room = await _repository.GetRoomByCapacity(capacity);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        [HttpPost]
        public async Task<ActionResult<Rooms>> PostRoom(Rooms room)
        {
            await _repository.Create(room);

            return CreatedAtAction("GetRoom", new { id = room.SId }, room);
        }

       
        [HttpPut]
        [ProducesResponseType(typeof(Rooms), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateRoom([FromBody] Rooms room)
        {
            return Ok(_repository.Update(room));
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Rooms), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Rooms>> DeleteRoom(int id)
        {
            var room = await _repository.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }

            return Ok( _repository.Delete(id));
        }

        
    }
}
