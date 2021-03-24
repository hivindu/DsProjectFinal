using Nusers.API.Data.Interfaces;
using Nusers.API.Entities;
using Nusers.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nusers.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        // Methods needs to be implemented
        private readonly IUserContext _context;

        public UserRepository(IUserContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<IEnumerable<Users>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<Users> GetUsers(int Uid)
        {
            throw new NotImplementedException();
        }

        public Task<Users> GetUserByBatch(string batch)
        {
            throw new NotImplementedException();
        }

        public Task<Users> GetUserByDegree(string degree)
        {
            throw new NotImplementedException();
        }

        public Task Create(Users users)
        {
            throw new NotImplementedException();
        }

        public Task Update(Users users)
        {
            throw new NotImplementedException();
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
