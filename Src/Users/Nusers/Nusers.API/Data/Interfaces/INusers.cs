using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nusers.API.Entities;

namespace Nusers.API.Data.Interfaces
{
    public interface INusers
    {
        public DbSet<Users> users { get; }
    }
}
