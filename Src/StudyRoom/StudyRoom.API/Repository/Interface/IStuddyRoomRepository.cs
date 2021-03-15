using StudyRoom.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyRoom.API.Repository.Interface
{
    public interface IStuddyRoomRepository
    {
        Task<IEnumerable<Rooms>> GetRooms();

        Task<Rooms> GetRoom(int Sid);

        Task<Rooms> GetRoomByOption(int option);

        Task<Rooms> GetRoomByCapacity(int capacity);

        Task Create(Rooms rooms);

        Task Update(Rooms rooms);

        Task Delete(int id);

    }
}
