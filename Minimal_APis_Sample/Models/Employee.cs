using System.ComponentModel.DataAnnotations;

namespace Minimal_APis_Sample.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; } 

        public string EmpId { get; set; }

        public string? EmpName { get; set; }    

        public int Salary {get; set; }
    }
}
