using Employees.API.Models;
using Employees.API.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Employees.API.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmpDbContext _EmpDbContext;

        public EmployeeRepository(EmpDbContext EmpDbContext)
        {
            _EmpDbContext=EmpDbContext;
        }

       
        public IEnumerable<EmployeeData> GetAllEmployees()
        {
            return _EmpDbContext.Employees.ToList();
        }

        

        public EmployeeData GetEmployeeById(Guid id)
        {
            var emp = _EmpDbContext.Employees.FirstOrDefault(e => e.EmpId == id);

            return emp;
        }

        public EmployeeData AddEmployee(EmployeeData e)
        {
            e.EmpId = new Guid();
           _EmpDbContext.Employees.AddAsync(e);
            _EmpDbContext.SaveChangesAsync();
            return e;
        }

        public string DeleteEmpById(Guid id)
        {
            var emp = _EmpDbContext.Employees.FirstOrDefault(e => e.EmpId == id);

             _EmpDbContext.Employees.Remove(emp);
            _EmpDbContext.SaveChangesAsync();



            return "Deleted";



        }

    }
}
