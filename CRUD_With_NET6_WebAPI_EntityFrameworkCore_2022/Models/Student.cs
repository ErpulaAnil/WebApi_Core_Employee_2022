
namespace CRUD_With_NET6_WebAPI_EntityFrameworkCore_2022.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;   
        public string FirstName { get; set; } = string.Empty;   
        public string LastName { get; set; } =string.Empty;
        public string Place { get; set; } =string.Empty;
    }
}
