using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.API.Data;

namespace EmployeeManagement.API.Data
{
    public class DbContextFactory : IDesignTimeDbContextFactory<AppDBContext>
    {
        public AppDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            //optionsBuilder.UseSqlite("Data Source=designdb.db");
            return new AppDBContext(optionsBuilder.Options);
        }
    }
}
