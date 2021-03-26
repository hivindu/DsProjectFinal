using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bookings.API.Data;

namespace Bookings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MyMDBController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IBook
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository repository;

        public MyMDBController(TRepository repository)
        {
            this.repository = repository;
        }


        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await repository.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var booking = await repository.Get(id);
            if (booking == null)
            {
                return NotFound();
            }
            return booking;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity booking)
        {
            if (id != booking.Id)
            {
                return BadRequest();
            }
            await repository.Update(booking);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity booking)
        {
            await repository.Add(booking);
            return CreatedAtAction("Get", new { id = booking.Id }, booking);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var booking = await repository.Delete(id);
            if (booking == null)
            {
                return NotFound();
            }
            return booking;
        }

    }
}
