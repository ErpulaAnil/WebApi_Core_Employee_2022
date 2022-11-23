using CRUD_With_NET6_WebAPI_EntityFrameworkCore_2022.Data;
using CRUD_With_NET6_WebAPI_EntityFrameworkCore_2022.Models;

namespace CRUD_With_NET6_WebAPI_EntityFrameworkCore_2022.Repository
{
    public class StudentService : IStudent
    {
        private readonly DataContext _studentContext;

        public StudentService(DataContext context)
        {
            _studentContext = context;
        }
        public IEnumerable<Student> AddStudents(Student students)
        {
            _studentContext.StudentsDb.Add(students);
            _studentContext.SaveChanges();
            return _studentContext.StudentsDb;
        }

        public void DeleteStudent(Student student)
        {
            _studentContext.StudentsDb.Remove(student);
            _studentContext.SaveChanges();
        }

        public IEnumerable<Student> GetAllStudents()
        {

            return _studentContext.StudentsDb.ToList();
        }

        public Student GetStudentData(int id)
        {
            return _studentContext.StudentsDb.Find(id);
        }

        public void UpdateStudent(Student student, Student std)
        {
         //   var student = _studentContext.StudentsDb.Find(std.id);

            student.Name = std.Name;
            student.FirstName = std.FirstName;
            student.LastName = std.LastName;
            student.Place = std.Place;
            _studentContext.Update(student);
           _studentContext.SaveChanges();
           // _studentContext.StudentsDb.ToList();
        }
    }
}
