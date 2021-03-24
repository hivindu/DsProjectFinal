using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyRoom.API.Model;

namespace StudyRoom.API.Data
{
    public class StudyRoomDbContext : DbContext
    {
        public StudyRoomDbContext (DbContextOptions<StudyRoomDbContext> options)
            : base(options)
        {
        }

        public DbSet<Rooms> Rooms { get; set; }
    }
}
