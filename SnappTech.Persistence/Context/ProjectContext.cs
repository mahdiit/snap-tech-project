using Microsoft.EntityFrameworkCore;
using SnappTech.Domain.Entities;
using SnappTech.Persistence.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Persistence.Context
{
    public class ProjectContext : BaseContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=SnappTech;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                    new User() { Id = 1001, Name = "admin" },
                    new User() { Id = 1002, Name = "hamster" },
                    new User() { Id = 1003, Name = "user" }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
