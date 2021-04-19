using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminUser.API.Data;
using AdminUser.API.Entities;
using AdminUser.API.Repositories.Interface;
using System.Net;

namespace AdminUser.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _repository;

        public AdminController(IAdminRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Admin
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserData>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<UserData>>> GetAdminUser()
        {
            var Admin = await _repository.GetAdminUser();

            return Ok(Admin);
        }

        // GET: api/Admin/5
        [HttpGet("{id}", Name = "GetAdmin")]
        public async Task<ActionResult<UserData>> GetAdminUser(int id)
        {
            var admin = await _repository.GetAdminUser(id);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

        [HttpGet("[action]/{id}/{pw}", Name = "GetAdmin")]
        public async Task<ActionResult<UserData>> GetUserByCredentials(int id,string pw)
        {
            var admin = await _repository.GetUserByCredentials(id,pw);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

        // PUT: api/Admin/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UserData), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateAdmin(int id, UserData admin)
        {
            if (id != admin.UId)
            {
                return BadRequest();
            }

            return Ok(await _repository.Update(admin));
        }

        // POST: api/Admin
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserData>> CreateAdmin(UserData admin)
        {
            await _repository.Create(admin);

            return CreatedAtAction("GetAdmin", new { id = admin.UId }, admin);
        }

        // DELETE: api/Admin/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UserData), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UserData>> DeleteAdmin(int id)
        {
            return Ok(await _repository.Delete(id));
        }
    }
}
