using Microsoft.EntityFrameworkCore;
using Nusers.API.Entities;
using Nusers.API.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nusers.API.Data
{
    public class UserContext
    {
        public UserContext(IUserDatabaseSettings settings)
        {
           
        }
        public DbSet<Users> users { get; }
    }
}
