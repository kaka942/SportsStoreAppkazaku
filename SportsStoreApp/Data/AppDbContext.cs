using Microsoft.EntityFrameworkCore;
using SportsStoreApp.Models;

namespace SportsStoreApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductUser> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // База данных в файле SportsStore.db (в папке с exe)
                optionsBuilder.UseSqlite("Data Source=SportsStore.db");
            }
        }
    }
}