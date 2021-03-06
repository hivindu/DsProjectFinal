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
        [ProducesResponseType(typeof(IEnumerable<UserData>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<UserData>>> GetUsers()
        {
            var Users = await _repository.GetUsers();

            return Ok(Users);
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUsers")]
        [ProducesResponseType(typeof(IEnumerable<UserData>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<UserData>>> GetAdminUser(int id)
        {
            var users = await _repository.GetUsers(id);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpGet("[action]/{id}/{pw}")]
        [ProducesResponseType(typeof(IEnumerable<UserData>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<UserData>>> GetUserByCredentials(int id, string pw)
        {
            var users = await _repository.GetUserByCredentials(id, pw);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users); 
        }

        // PUT: api/User/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        [ProducesResponseType(typeof(UserData), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateUser([FromBody] UserData users)
        {
            return Ok(await _repository.Update(users));
        }

        // POST: api/User
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserData>> CreateUser(UserData users)
        {
            await _repository.Create(users);

            return CreatedAtAction("GetUsers", new { id = users.UId }, users);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UserData), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UserData>> DeleteUser(int id)
        {
            return Ok(await _repository.Delete(id));
        }

        [HttpGet("[action]/{degree}")]
        [ProducesResponseType(typeof(IEnumerable<UserData>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UserData>> GetUserByDegree(string degree)
        {
            var users = await _repository.GetUserByDegree(degree);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpGet("[action]/{batch}")]
        [ProducesResponseType(typeof(IEnumerable<UserData>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UserData>> GetUserByBatch(string batch)
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
