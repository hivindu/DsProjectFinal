using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyRoom.API.Data.EFCore
{
    public abstract class EFCoreRepository<RoomEntity, StudyRoomAPIContext> : IRoomRepository<RoomEntity> where RoomEntity : class, IEntity where StudyRoomAPIContext : DbContext
    {
        public Task<RoomEntity> Add(RoomEntity room)
        {
            throw new NotImplementedException();
        }

        public Task<RoomEntity> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RoomEntity>> GetAllRooms()
        {
            throw new NotImplementedException();
        }

        public Task<RoomEntity> GetRoom(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RoomEntity> Update(RoomEntity room)
        {
            throw new NotImplementedException();
        }
    }
}
