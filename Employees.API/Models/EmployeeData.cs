using System.ComponentModel.DataAnnotations;

namespace Employees.API.Models
{
    public class EmployeeData
 {
        [Key]
        public Guid EmpId { get; set; }
        public string EmpName { get; set; }

        public string EmpEmail { get; set; }  

        public long EmpPhoneNo { get; set; }    

        public long EmpSalary { get; set; }

        public string EmpDepartment { get; set; }   

    }
}
