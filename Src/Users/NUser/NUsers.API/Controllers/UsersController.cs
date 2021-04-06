using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUsers.API.Data;
using NUsers.API.Entities;
using NUsers.API.Repositories.Interfaces;

namespace NUsers.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        // GET: api/User
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Users>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            var Users = await _repository.GetUsers();

            return Ok(Users);
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUsers")]
        public async Task<ActionResult<Users>> GetAdminUser(int id)
        {
            var users = await _repository.GetUsers(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Users), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateUser(int id, Users users)
        {
            if (id != users.UId)
            {
                return BadRequest();
            }

            return Ok(await _repository.Update(users));
        }

        // POST: api/User
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Users>> CreateUser(Users users)
        {
            await _repository.Create(users);

            return CreatedAtAction("GetUsers", new { id = users.UId }, users);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Users), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Users>> DeleteUser(int id)
        {
            return Ok(await _repository.Delete(id));
        }

        [HttpGet("[action]/{degree}")]
        [ProducesResponseType(typeof(IEnumerable<Users>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Users>> GetUserByDegree(string degree)
        {
            var users = await _repository.GetUserByDegree(degree);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpGet("[action]/{batch}")]
        [ProducesResponseType(typeof(IEnumerable<Users>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Users>> GetUserByBatch(string batch)
        {
            var users = await _repository.GetUserByBatch(batch);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }
    }
}
