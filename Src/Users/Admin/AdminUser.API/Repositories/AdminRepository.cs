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

        public async Task<IEnumerable<UserData>> GetAdminUser()
        {
            string query = "EXEC SelAllAdmins;";
            return await _context.userData.FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<UserData>> GetAdminUser(int Id)
        {
            string query = "EXEC SelAdminById @id=" + Id + "";
            return _context.userData.FromSqlRaw(query).AsEnumerable();
        }

        public async Task<IEnumerable<UserData>> GetUserByCredentials(int id, string password)
        {
            string query = "EXEC SelUserByCredentials @ID=" + id + ",@PW="+ password+"";
            return  _context.userData.FromSqlRaw(query).AsEnumerable(); 
        }

        public async Task Create(UserData admin)
        {
            int id = admin.UId;
            string f_name = admin.F_name;
            string l_name = admin.L_name;
            int contact = admin.Contact;
            string address = admin.Address;
            string batch = admin.Batch;
            string degree = admin.Degree;
            string password = admin.Password;
            int type = admin.Type;

            var rest = _context.Database.ExecuteSqlCommand("EXEC InsAdmin @UId='" + id + "', @F_name='" + f_name + "',@L_name='" + l_name + "',@Contact='" + contact + "',@Address='" + address + "' , @Password = '" + password + "', @Type = '" + type + "'");

        }

        public async Task<bool> Update(UserData admin)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC UpdUser @UId='" + admin.UId + "',@F_name='" + admin.F_name + "',@L_name='" + admin.L_name + "',@Contact='" + admin.Contact + "',@Address='" + admin.Address + "',@Password='" + admin.Password + "',@Type='" + admin.Type + "'");

            return Convert.ToBoolean(res);
        }

        public async Task<bool> Delete(int id)
        {
            string query = "EXEC DelUser @Uid=" + id + "";

            var res = _context.Database.ExecuteSqlCommand("EXEC DelUser @Uid='" + id + "'");

            return Convert.ToBoolean(res);
        }

       
    }
}
