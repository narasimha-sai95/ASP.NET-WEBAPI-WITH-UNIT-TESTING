using Employees.API.Data;
using Employees.API.Models;
using Employees.API.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employees.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        public EmployeesController(IEmployeeRepository EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }


        [HttpGet]

       
        public ActionResult GetAllEmployees()
        {
            try
            {
                return Ok(_EmployeeRepository.GetAllEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error retrieving data from the database");
            }
        }

        [HttpGet]
        [Route("{id:guid}")]

        public ActionResult GetEmploeeById(Guid id)
        {
            try
            {
                var employee = _EmployeeRepository.GetEmployeeById(id);

                if(employee == null)
                {
                    return NotFound();  
                }
                return Ok(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");

            }

        }

        [HttpPost]
        
        public ActionResult AddEmployee(EmployeeData e)
        {
            try
            {
                if (e == null)
                {
                    return BadRequest();
                }
                var employee = _EmployeeRepository.AddEmployee(e);
                

                return StatusCode(StatusCodes.Status201Created, employee);


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error creating new employee record");
            }
        }


        [HttpDelete]
        [Route("{id:guid}")]

        public ActionResult DeleteEmpById (Guid id)
        {

            try
            {
                var employee = _EmployeeRepository.GetEmployeeById(id);

                if(employee == null)
                {
                    return NotFound($"Employee with id {id} not found");
                }
               var msg= _EmployeeRepository.DeleteEmpById(id);


                return StatusCode(StatusCodes.Status204NoContent, msg);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }



        }


    }
}
