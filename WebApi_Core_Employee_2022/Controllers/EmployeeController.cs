using Microsoft.AspNetCore.Mvc;
using WebApi_Core_Employee_2022.Models;
using WebApi_Core_Employee_2022.Repository;

namespace WebApi_Core_Employee_2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _dataRepository;

        public EmployeeController(IEmployee dataRepository)
        {
            _dataRepository = dataRepository;
        }

        //Get All Employees
        [HttpGet]
        public IActionResult GetAllEmps()
        {
            IEnumerable<Employee> employees = _dataRepository.GetAllEmployees();
            return Ok(employees);
        }

        //Get Particular Employee 

        // GET: api/Employee/5
        // [HttpGet("{id}", Name = "Get")]
        //public IActionResult GetEmp(long id)
        //{
        //    EmployeeModel employee = _dataRepository.GetEmployee(id);
        //    if (employee == null)
        //    {
        //        return NotFound("The Employee record couldn't be found.");
        //    }
        //    return Ok(employee);
        //}
        //Both Are same above Method
        [HttpGet("{id}")]
        public IActionResult GetEmp(long id)
        {
            Employee obj = new Employee();
            obj = _dataRepository.GetEmployee(id);
            if (obj == null)
            {
                return NotFound("The Employee record couldn't be found");
            }
            return Ok(obj);
        }

        //Delete Employee

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmp(long id)
        {
            Employee obj = new Employee();
            obj = _dataRepository.GetEmployee(id);
            if (obj == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            _dataRepository.DeleteEmployee(obj);

            return NoContent();
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult UpdateEmp(long id, Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null.");
            }
            Employee employeeToUpdate = new Employee();
            employeeToUpdate = _dataRepository.GetEmployee(id);

            if (employeeToUpdate == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            _dataRepository.UpdateEmployee(employeeToUpdate, employee);
            return Ok("Success");
        }

        //Adding Employee
        [HttpPost, Route("AddEmp")]
        public IEnumerable<Employee> AddEmp(Employee employee)
        {   
            return _dataRepository.AddEmployee(employee);
            //return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.EmployeeId, employee);

        }


    }
}
