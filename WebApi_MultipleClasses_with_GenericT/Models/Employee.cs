using System.ComponentModel.DataAnnotations;

namespace WebApi_MultipleClasses_with_GenericT.Models
{
    public class Employee
    {
        [Key]
        public int RegId { get; set; } 

        public string EmployeeId { get; set; } 

        public string EmployeeName { get; set; }

        public string EmployeeSalary { get; set; }  
    }
}
