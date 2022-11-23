using System.ComponentModel.DataAnnotations;

namespace WebApi_Core_Employee_2022.Models
{
    public class Employee
    {
        [Key]
        public long EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string?PhoneNumber { get; set; }
        public string?Email { get; set; }
    }
}
