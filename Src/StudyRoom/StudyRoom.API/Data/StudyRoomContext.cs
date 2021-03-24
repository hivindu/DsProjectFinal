using Microsoft.EntityFrameworkCore;
using StudyRoom.API.Data.Interface;
using StudyRoom.API.Entities;
using StudyRoom.API.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyRoom.API.Data
{
    public class StudyRoomContext : IStudyRoomContext
    {
        public StudyRoomContext(IStudyRoomDatabaseSettings settings)
        {
            StudyRoomContextSeed.SeedingData();
        }
        public DbSet<Rooms> rooms { get; }
    }
}
