using AdminUser.API.Data;
using AdminUser.API.Entities;
using AdminUser.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUser.API.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AdminUserDBContext _context;

        public AdminRepository(AdminUserDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Admin>> GetAdminUser()
        {
            string query = "";
            return await _context.AdminUser.FromSqlRaw(query).ToListAsync();
        }

        public async Task<Admin> GetAdminUser(int Id)
        {
            string query = "";
            return _context.AdminUser.FromSqlRaw(query).FirstOrDefault();
        }

        public async Task Create(Admin admin)
        {
            string query = "";


            _context.AdminUser.FromSqlRaw(query);
        }

        public async Task<bool> Update(Admin admin)
        {
            string query = "";

            var res = _context.AdminUser.FromSqlRaw(query).ToListAsync();

            return Convert.ToBoolean(res);
        }

        public async Task<bool> Delete(int Id)
        {
            string query = "";

            var res = _context.AdminUser.FromSqlRaw(query);

            return Convert.ToBoolean(res);
        }
    }
}
