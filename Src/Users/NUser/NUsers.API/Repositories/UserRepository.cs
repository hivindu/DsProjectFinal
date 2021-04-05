using Microsoft.EntityFrameworkCore;
using NUsers.API.Data;
using NUsers.API.Entities;
using NUsers.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUsers.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NUsersDBContext _context;

        public UserRepository(NUsersDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            string query = "";
            return await _context.Users.FromSqlRaw(query).ToListAsync();
        }

        public Task<Users> GetUsers(int Id)
        {
            string query = "";
            return Task.FromResult(_context.Users.FromSqlRaw(query).FirstOrDefault());
        }

        public async Task<IEnumerable<Users>> GetUserByDegree(string degree )
        {
            //string query = "";

            return await _context.Users.FromSqlRaw("").ToListAsync();
        }

        public async Task<IEnumerable<Users>> GetUserByBatch(string batch)
        {
            //string query = "";

            return await _context.Users.FromSqlRaw("").ToListAsync();
        }

        public Task Create(Users user)
        {
            string query = "";


            _context.Users.FromSqlRaw(query);
            return Task.CompletedTask;
        }

        public Task<bool> Update(Users user)
        {
            string query = "";

            var res = _context.Users.FromSqlRaw(query).ToListAsync();

            return Task.FromResult(Convert.ToBoolean(res));
        }

        public Task<bool> Delete(int Id)
        {
            string query = "";

            var res = _context.Users.FromSqlRaw(query);

            return Task.FromResult(Convert.ToBoolean(res));
        }
    }
}
