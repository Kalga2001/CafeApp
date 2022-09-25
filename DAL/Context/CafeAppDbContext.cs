using CafeApp.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.DAL.Context
{
    public class CafeAppDbContext : DbContext
    {
        public DbSet<Cooks> Cooks { get; set; }
        public DbSet<Dishes> Dishes { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public CafeAppDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CafeAppDb;Trusted_Connection=True;");
        }


    }


}
