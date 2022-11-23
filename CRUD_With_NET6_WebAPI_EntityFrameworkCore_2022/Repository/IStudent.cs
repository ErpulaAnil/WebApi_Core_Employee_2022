using CRUD_With_NET6_WebAPI_EntityFrameworkCore_2022.Models;
using System.Collections.Generic;

namespace CRUD_With_NET6_WebAPI_EntityFrameworkCore_2022.Repository
{
    public interface IStudent
    {
        IEnumerable<Student> GetAllStudents();
         Student GetStudentData(int id);
      
        void DeleteStudent(Student student);
        IEnumerable<Student> AddStudents(Student students);

        void UpdateStudent(Student student,Student std);
    }
}
