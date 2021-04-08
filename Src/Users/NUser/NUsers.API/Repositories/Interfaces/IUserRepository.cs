using NUsers.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUsers.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserData>> GetUsers();

        Task<UserData> GetUsers(int Id);

        Task<IEnumerable<UserData>> GetUserByDegree(string degree);

        Task<IEnumerable<UserData>> GetUserByBatch(string batch);

        Task Create(UserData user);

        Task<bool> Update(UserData user);

        Task<bool> Delete(int Id);
    }
}
