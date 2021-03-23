using Nusers.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nusers.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> GetUsers();

        Task<Users> GetUsers(int Uid);

        Task<Users> GetUserByBatch(string batch);

        Task<Users> GetUserByDegree(string degree);

        Task Create(Users users);

        Task Update(Users users);

        Task Delete(int id);
    }
}
