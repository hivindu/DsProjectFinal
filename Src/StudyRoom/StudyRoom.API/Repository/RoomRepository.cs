using Microsoft.EntityFrameworkCore;
using StudyRoom.API.Data;
using StudyRoom.API.Model;
using StudyRoom.API.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyRoom.API.Repository
{
    public class RoomRepository : IRoomsRepository
    {
        private readonly StudyRoomDbContext _context;

        public RoomRepository(StudyRoomDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rooms>> GetRooms()
        {
            string query = "";
            return await _context.Rooms.FromSqlRaw(query).ToListAsync();
        }

        public async Task<Rooms> GetRoom(int Id)
        {
            string query = "";
            return  _context.Rooms.FromSqlRaw(query).FirstOrDefault();
        }

        public async Task<IEnumerable<Rooms>> GetRoomByOption(int option)
        {
            string query = "";

            return await _context.Rooms.FromSqlRaw(query).ToListAsync();
        }

        
        public async Task Create(Rooms room)
        {
            string query = "";

           
            _context.Rooms.FromSqlRaw(query);
        }

        public async Task<bool> Update(Rooms room)
        {
            string query = "";

            var res = _context.Rooms.FromSqlRaw(query).ToListAsync();

            return Convert.ToBoolean(res);
        }

        public async Task<bool> Delete(int Id)
        {
            string query = "";

            var res = _context.Rooms.FromSqlRaw(query);

            return Convert.ToBoolean(res);
        }


    }
}
