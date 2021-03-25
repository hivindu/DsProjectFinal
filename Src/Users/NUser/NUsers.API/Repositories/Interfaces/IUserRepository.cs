using NUsers.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUsers.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users>> GetUsers();

        Task<Users> GetUsers(int Id);

        Task<IEnumerable<Users>> GetUserByDegree(int degree);

        Task<IEnumerable<Users>> GetUserByBatch(int batch);

        Task Create(Users user);

        Task<bool> Update(Users user);

        Task<bool> Delete(int Id);
    }
}
