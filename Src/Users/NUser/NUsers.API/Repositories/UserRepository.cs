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

        public async Task<IEnumerable<UserData>> GetUsers()
        {
            string query = "EXEC SelAllUsers;";
            return await _context.userData.FromSqlRaw(query).ToListAsync();
        }

        public Task<UserData> GetUsers(int Id)
        {
            string query = "EXEC SelUserById @id=" + Id + "";
            return Task.FromResult(_context.userData.FromSqlRaw(query).FirstOrDefault());
        }

        public async Task<IEnumerable<UserData>> GetUserByDegree(string degree )
        {
            //string query = "";

            return await _context.userData.FromSqlRaw("EXEC SelUserByDegree @degree =" + degree + "").ToListAsync();
        }

        public async Task<IEnumerable<UserData>> GetUserByBatch(string batch)
        {
            //string query = "";

            return await _context.userData.FromSqlRaw("EXEC SelUserByBatch @batch =" + batch + "").ToListAsync();
        }

        public Task<UserData> GetUserByCredentials(int id, string password)
        {
            string query = "EXEC SelUserByCredentials @ID=" + id + ",@PW=" + password + "";
            return Task.FromResult(_context.userData.FromSqlRaw(query).FirstOrDefault());
        }

        public async Task Create(UserData user)
        {
            int id = user.UId;
            string f_name = user.F_name;
            string l_name = user.L_name;
            int contact = user.Contact;
            string address = user.Address;
            string batch = user.Batch;
            string degree = user.Degree;
            string password = user.Password;
            int type = user.Type;

            var rest = _context.Database.ExecuteSqlCommand("EXEC InsUser @UId='" + id + "', @F_name='" + f_name + "',@L_name='" + l_name + "',@Contact='" + contact + "',@Address='" + address + "' ,@Batch = '" + batch + "', @Degree = '" + degree + "', @Password = '" + password + "', @Type = '" + type + "'");

            //string query = "";

        }

        public async Task<bool> Update(UserData user)
        {
            //string query = "";

            var res = _context.Database.ExecuteSqlCommand("EXEC UpdUser @UId='" + user.UId + "',@F_name='" + user.F_name + "',@L_name='" + user.L_name + "',@Contact='" + user.Contact + "',@Address='" + user.Address + "',@Batch='" + user.Batch + "',@Degree='" + user.Degree + "',@Password='" + user.Password + "',@Type='" + user.Type + "'");


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
