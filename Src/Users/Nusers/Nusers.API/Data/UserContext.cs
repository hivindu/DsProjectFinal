using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nusers.API.Data
{
    public class UserContext
    {
        public StudyRoomContext(IUserDatabaseSettings settings)
        {
            StudyRoomConytextSeed.SeedingData();
        }
        public DbSet<Users> users { get; }
    }
}
