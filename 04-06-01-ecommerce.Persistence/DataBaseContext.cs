using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_06_01_ecommerce.Persistence
{
    public class DataBaseContext:DbContext , IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) :base (options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UsersInRoles { get; set; }

    }
}
