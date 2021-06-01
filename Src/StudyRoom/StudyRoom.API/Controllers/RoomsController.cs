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
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Rooms), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Rooms>> GetRoom(int id)
        {
            var rooms = await _repository.GetRoom(id);

            if (rooms == null)
            {
                return NotFound();
            }

            return Ok(rooms);
        }

        [HttpGet("[action]/{option}")]
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


        [HttpGet("[action]/{slot}/{date}")]
        [ProducesResponseType(typeof(IEnumerable<Rooms>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Rooms>>> GetBookingsByTime(int slot, string date)
        {
            var bookings = await _repository.GetBookingByTime(slot, date);

            if (bookings == null)
            {
                return NotFound();
            }

            return Ok(bookings);
        }

        [HttpGet("[action]/{slot}/{date}/{id}")]
        [ProducesResponseType(typeof(IEnumerable<Rooms>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Rooms>>> GetExist(int slot, string date,int id)
        {
            var bookings = await _repository.GetExist(slot, date,id);

            if (bookings == null)
            {
                return NotFound();
            }

            return Ok(bookings);
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(typeof(IEnumerable<Rooms>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Rooms>>> GetRoomByBooking(int id)
        {
            var bookings = await _repository.GetRoomByBooking(id);

            if (bookings == null)
            {
                return NotFound();
            }

            return Ok(bookings);
        }


        [HttpPost]
        public async Task<ActionResult<Rooms>> CreateRoom([FromBody]Rooms rooms)
        {
            await _repository.Create(rooms);

            return CreatedAtAction("GetRooms", new { id = rooms.SId }, rooms);
        }

      
        [HttpPut]
        [ProducesResponseType(typeof(Rooms), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateRoom([FromBody] Rooms rooms)
        {
            if (rooms.SId != rooms.SId)
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
