using CRUD_With_NET6_WebAPI_EntityFrameworkCore_2022.Models;
using CRUD_With_NET6_WebAPI_EntityFrameworkCore_2022.Repository;

using Microsoft.AspNetCore.Mvc;

namespace CRUD_With_NET6_WebAPI_EntityFrameworkCore_2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudent _dataRepository;

        public StudentsController(IStudent dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpPost, Route("AddStd")]
        public IEnumerable<Student> AddStd(Student employee)
        {
            return _dataRepository.AddStudents(employee);
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            IEnumerable<Student> students= _dataRepository.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
          //Student obj = new Student();
          var obj = _dataRepository.GetStudentData(id);
            if (obj == null)
            {
                return NotFound("The Student record couldn't be found");
            }
            return Ok(obj);
        }
        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStd(int id)
        {
            
          var obj = _dataRepository.GetStudentData(id);
            if (obj == null)
            {
                return NotFound("The Student record couldn't be found.");
            }
            _dataRepository.DeleteStudent(obj);

            return Ok("Deleted Sucessfully");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStd(Student student,int id)
        {
          
           var studentToUpdate = _dataRepository.GetStudentData(id);

            if (studentToUpdate == null)
            {
                return NotFound("The student record couldn't be found.");
            }

            _dataRepository.UpdateStudent(studentToUpdate,student);

            return Ok("Success");
        }

    }
}
