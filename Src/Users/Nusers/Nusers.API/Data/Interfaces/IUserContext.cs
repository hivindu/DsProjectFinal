using Microsoft.EntityFrameworkCore;
using Nusers.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nusers.API.Data.Interfaces
{
    public interface IUserContext
    {
        public DbSet<Users> users { get; }
    }
}
