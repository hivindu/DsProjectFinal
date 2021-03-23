using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nusers.API.Data;
using Nusers.API.Entities;
using Nusers.API.Repositories.Interfaces;

namespace Nusers.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NusersController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly ILogger<NusersController> _logger;

        public NusersController(IUserRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET: api/Users
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Users>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            var result = await _repository.GetUsers();
            return Ok(result);
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult<Users>> Get(int id)
        {
            var user = await _repository.GetUsers(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/User/1
        [HttpGet("{batch}")]
        public async Task<ActionResult<Users>> GetUserByBatch(string batch)
        {
            var user = await _repository.GetUserByBatch(batch);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet("{degree}")]
        public async Task<ActionResult<Users>> GetUserByDegree(string degree)
        {
            var user = await _repository.GetUserByDegree(degree);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<Users>> PostUser(Users user)
        {
            await _repository.Create(user);

            return CreatedAtAction("GetUser", new { id = user.UId }, user);
        }


        [HttpPut]
        [ProducesResponseType(typeof(Users), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateUser([FromBody] Users user)
        {
            return Ok(_repository.Update(user));
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Users), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Users>> DeleteUser(int id)
        {
            var room = await _repository.GetUsers(id);
            if (room == null)
            {
                return NotFound();
            }

            return Ok(_repository.Delete(id));
        }
    }
}
