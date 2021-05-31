using Microsoft.Data.SqlClient;
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
            string query = "EXEC SelAllRooms;";
            return await _context.Rooms.FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<Rooms>> GetRoom(int Id)
        {
            
            return await  _context.Rooms.FromSqlRaw("EXEC SelRoomById @id="+Id+"").ToListAsync();
        }

        public async Task<IEnumerable<Rooms>> GetRoomByOption(int option)
        {
            //string query = "";

            return await _context.Rooms.FromSqlRaw("EXEC SelRoomByOption @option =" + option + "").ToListAsync();
        }


        public async Task<IEnumerable<Rooms>> GetBookingByTime(DateTime ftime, DateTime toTime, DateTime date)
        {
            string query = "EXEC SelAllBookingsByTime @fTime='" + ftime + "', @tTime='" + toTime + "',@rdate ='" + date + "'";
            return await _context.Rooms.FromSqlRaw(query).ToListAsync();
        }


        public async Task<IEnumerable<Rooms>> GetRoomByBooking(int Id)
        {
            string query = "EXEC SelRoomsByBooking @id='" + Id + "'";
            return await _context.Rooms.FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<Rooms>> GetExist(DateTime ftime, DateTime toTime, DateTime date, int id)
        {
            string query = "EXEC AvailabilityCheck @fTime='" + ftime + "', @tTime='" + toTime + "',@rdate ='" + date + "',@id='"+id+"'";
            return await _context.Rooms.FromSqlRaw(query).ToListAsync();
        }

        public async Task Create(Rooms room)
        {
            // string query = "EXEC InsStudyRoom @SId="+room.SId+ ",@Floor="+room.Floor+ ",@Capacity="+room.Capacity+ ",@location="+room.Location+ ",@type="+room.Options+"";

            int id = room.SId;
            int floor = room.Floor;
            int capacity = room.Capacity;
            string location = room.Location;
            int option = room.Options;

            var rest = _context.Database.ExecuteSqlCommand("EXEC InsStudyRoom @SId="+id+", @Floor="+floor+",@Capacity="+capacity+",@location='"+ location + "',@type="+option+"");
            //var res = _context.Database.ExecuteSqlRaw("EXEC InsStudyRoom @SId, @Floor,@Capacity,@location,@type", parameters:new[] {""+ids+"",""+floor+""+capacity+"",""+location+"",""+option+""});
            
        }

        public async Task<bool> Update(Rooms room)
        {
            var res = _context.Database.ExecuteSqlCommand("EXEC UpdRoom @SId=" + room.SId + ",@Floor=" + room.Floor + ",@Capacity=" + room.Capacity + ",@location='" + room.Location + "',@Options=" + room.Options + "");
            return Convert.ToBoolean(res);
        }

        public async Task<bool> Delete(int Id)
        {
            string query = "EXEC DelRoom @sid="+Id+"";

            var res = _context.Database.ExecuteSqlCommand("EXEC DelRoom @sid='" + Id + "'");

            return Convert.ToBoolean(res);
        }

        
    }
}
