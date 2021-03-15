using Microsoft.EntityFrameworkCore;
using StudyRoom.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyRoom.API.Data.Interface
{
    public interface IStudyRoomContext
    {
        public DbSet<Rooms> rooms { get; }
    }
}
