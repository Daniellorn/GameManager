using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwer.Data
{
    public class MyDBContext : DbContext
    {
        public DbSet<DataServer> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-6TTPBBUD\\SQLEXPRESS;Initial Catalog=GameManagerDB;Integrated Security=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataServer>().HasKey(d => d.GameId);
            modelBuilder.Entity<DataServer>().Property(m => m.Developer).IsRequired(false);
            modelBuilder.Entity<DataServer>().Property(m => m.Review).IsRequired(false);
            modelBuilder.Entity<DataServer>().Property(m => m.Rating).IsRequired(false);
            modelBuilder.Entity<DataServer>().Property(m => m.Title).IsRequired(false);
        }
    }
}
