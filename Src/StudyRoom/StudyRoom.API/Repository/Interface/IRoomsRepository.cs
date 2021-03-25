using StudyRoom.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyRoom.API.Repository.Interface
{
    public interface IRoomsRepository
    {
        Task<IEnumerable<Rooms>> GetRooms();

        Task<Rooms> GetRoom(int Id);

        Task<IEnumerable<Rooms>> GetRoomByOption(int option);

        Task Create(Rooms room);

        Task<bool> Update(Rooms room);

        Task<bool> Delete(int Id);
    }
}
