using Employees.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Employees.API.Data
{
    public class EmpDbContext : DbContext

    {
        public EmpDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EmployeeData> Employees { get; set; }  


    }
}
