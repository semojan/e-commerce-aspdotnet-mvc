using _04_06_01_ecommerce.Application.Interface.Context;
using _04_06_01_ecommerce.Common.Role;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = nameof(UserRoles.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = nameof(UserRoles.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = nameof(UserRoles.Customer) });
        }
    }
}
