using EmployeeManagement.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Data
{
    public class AppDBContext : DbContext // ORM - Object Relationship Mapping
    {
        public AppDBContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; } // Table Name

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = ./data/SampleDb.db"); // DB Name
        }
    }
}
