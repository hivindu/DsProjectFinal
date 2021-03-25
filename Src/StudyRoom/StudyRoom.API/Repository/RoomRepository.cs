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

        
        public Task Create(Rooms room)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Rooms room)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }


    }
}
