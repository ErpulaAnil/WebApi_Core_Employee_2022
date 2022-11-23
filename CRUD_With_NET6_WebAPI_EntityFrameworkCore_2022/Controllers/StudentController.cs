using CRUD_With_NET6_WebAPI_EntityFrameworkCore_2022.Data;
using CRUD_With_NET6_WebAPI_EntityFrameworkCore_2022.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_With_NET6_WebAPI_EntityFrameworkCore_2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //private static List<Student> students = new List<Student>
        //     {
        //         new Student {
        //             Id = 1,
        //             Name ="Anil Kumar Erpula",
        //             FirstName="Anil",
        //             LastName="Kumar",
        //             Place="Hyderabad"
        //         },
        //         new Student {
        //             Id = 2,
        //             Name ="Sony Lekkalwar",
        //             FirstName="Sony",
        //             LastName="Lekkalwar",
        //             Place="Maharasta"
        //         }
        //     };
        // [HttpGet("{id}")]
        //// public  async Task<ActionResult<Student>> Get(int id)   
        // public async Task<IActionResult> Get(int id)
        // {
        //   var student=students.Find(x =>x.Id == id);
        //     if (student == null)
        //     {
        //         return BadRequest("student not found");  
        //     }   
        //     return Ok(student);
        // } 

        // [HttpPut]
        // public  async Task<ActionResult<Student>> Get(int id)   
        // public async Task<IActionResult> UpdateStudent(Student std)
        // {
        //     var student = students.Find(x => x.Id == std.Id);
        //     if (student == null)
        //     {
        //         return BadRequest("student not found");
        //     }
        //     student.Id=std.Id;  
        //     student.Name=std.Name;  
        //     student.FirstName=std.FirstName;    
        //     student.LastName=std.LastName;  
        //     student.Place=std.Place;
        //     return Ok(students);
        // }
        // [HttpGet]
        // public async Task<ActionResult<List<Student>>> GetAll()
        // public async Task<IActionResult> GetAll()
        // {

        //     return Ok(students);
        // }

        // [HttpPost]
        // // public async Task<ActionResult<List<Student>>> GetAll()
        // public async Task<IActionResult> AddStudents(Student student)
        // {
        //     students.Add(student);
        //     return Ok(students);
        // }

        // [HttpDelete("{id}")]
        //public async Task<ActionResult<List<Student>>> Delete()
        // public async Task<IActionResult> Delete(int id)
        // {
        //     var student = students.Find(x => x.Id == id);
        //     if (student == null)
        //     {
        //         return BadRequest("student not found");
        //     }
        //     students.Remove(student);

        //     return Ok(students);
        // }
        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        // public async Task<ActionResult<List<Student>>> GetAll()
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _context.StudentsDb.ToListAsync());
        }

        [HttpGet("{id}")]
        // public async Task<ActionResult<List<Student>>> GetStudentData()
        public async Task<IActionResult> GetStudentData(int id)
        {
            var student = await _context.StudentsDb.FindAsync(id);
            if (student == null)
            {
                return BadRequest("student not found");
            }
            return Ok(student);
        }

        [HttpDelete("{id}")]
        // public async Task<ActionResult<List<Student>>> Delete()
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.StudentsDb.FindAsync(id);
            if (student == null)
            {
                return BadRequest("student not found");
            }
            _context.StudentsDb.Remove(student);
            await _context.SaveChangesAsync();

            return Ok(await _context.StudentsDb.ToListAsync());
        }

        [HttpPost]
        // public async Task<ActionResult<List<Student>>> AddStudents()
        public async Task<IActionResult> AddStudents(Student student)
        {
            _context.StudentsDb.Add(student);
            await _context.SaveChangesAsync();
            return Ok(await _context.StudentsDb.ToListAsync());
        }

        [HttpPut]
        //public async Task<ActionResult<Student>> Get(int id)
        public async Task<IActionResult> UpdateStudent(Student newstd)
        {
            var oldstudent = await _context.StudentsDb.FindAsync(newstd.Id);
            if (oldstudent == null)
            {
                return BadRequest("student not found");
            }
            oldstudent.Name = newstd.Name;
            oldstudent.FirstName = newstd.FirstName;
            oldstudent.LastName = newstd.LastName;
            oldstudent.Place = newstd.Place;
            await _context.SaveChangesAsync();
            return Ok(await _context.StudentsDb.ToListAsync());
        }
    }
}
