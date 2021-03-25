using AdminUser.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUser.API.Repositories.Interface
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Admin>> GetAdminUser();

        Task<Admin> GetAdminUser(int Id);

        Task Create(Admin admin);

        Task<bool> Update(Admin admin);

        Task<bool> Delete(int Id);
    }
}
