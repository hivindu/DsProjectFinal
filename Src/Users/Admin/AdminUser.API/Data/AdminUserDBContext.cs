using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdminUser.API.Entities;

namespace AdminUser.API.Data
{
    public class AdminUserDBContext : DbContext
    {
        public AdminUserDBContext (DbContextOptions<AdminUserDBContext> options)
            : base(options)
        {
        }

        public DbSet<UserData> userData { get; set; }
    }
}
