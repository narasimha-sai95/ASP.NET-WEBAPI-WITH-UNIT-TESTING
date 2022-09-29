namespace Employees.API.Models.Repositories
{
    public interface IEmployeeRepository
    {
        public IEnumerable<EmployeeData> GetAllEmployees();

       public EmployeeData GetEmployeeById(Guid id);



       public EmployeeData AddEmployee(EmployeeData e);

       public string DeleteEmpById(Guid id);



    }
}
