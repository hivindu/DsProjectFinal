using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyRoom.API.Models;

namespace StudyRoom.API.Data
{
    public class StudyRoomAPIContext : DbContext
    {
        public StudyRoomAPIContext (DbContextOptions<StudyRoomAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Room> Room { get; set; }
    }
}
