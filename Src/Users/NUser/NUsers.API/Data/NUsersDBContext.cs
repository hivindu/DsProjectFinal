using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUsers.API.Entities;

namespace NUsers.API.Data
{
    public class NUsersDBContext : DbContext
    {
        public NUsersDBContext (DbContextOptions<NUsersDBContext> options)
            : base(options)
        {
        }

        public DbSet<NUsers.API.Entities.Users> Users { get; set; }
    }
}
