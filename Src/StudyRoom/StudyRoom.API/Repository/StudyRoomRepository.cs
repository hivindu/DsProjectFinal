using StudyRoom.API.Entities;
using StudyRoom.API.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyRoom.API.Repository
{
    public class StudyRoomRepository : IStuddyRoomRepository
    {
        public Task<Rooms> GetRoom(int Sid)
        {
            throw new NotImplementedException();
        }

        public Task<Rooms> GetRoomByCapacity(int capacity)
        {
            throw new NotImplementedException();
        }

        public Task<Rooms> GetRoomByOption(int option)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Rooms>> GetRooms()
        {
            throw new NotImplementedException();
        }

        public Task Create(Rooms rooms)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
0
        public Task Update(Rooms rooms)
        {
            throw new NotImplementedException();
        }
    }
}
