using AdminUser.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUser.API.Repositories.Interface
{
    public interface IAdminRepository
    {
        Task<IEnumerable<UserData>> GetAdminUser();

        Task<UserData> GetAdminUser(int Id);

        Task Create(UserData admin);

        Task<bool> Update(UserData admin);

        Task<bool> Delete(int Id);
    }
}
