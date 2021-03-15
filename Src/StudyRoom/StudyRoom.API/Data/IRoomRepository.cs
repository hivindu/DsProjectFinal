using StudyRoom.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyRoom.API.Data
{
    public interface IRoomRepository<Room> where Room: class, IEntity
    {
        Task<List<Room>> GetAllRooms();
        Task<Room> GetRoom(int id);
        Task<Room> Add(Room room);
        Task<Room> Update(Room room);
        Task<Room> Delete(int id);
    }
}
