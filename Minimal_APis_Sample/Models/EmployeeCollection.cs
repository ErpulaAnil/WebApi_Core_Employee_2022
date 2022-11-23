namespace Minimal_APis_Sample.Models
{
    public class EmployeeCollection
    {
        public List<Employee> Employees { get; set;}

        public List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                      EmpId = "11",
                      EmpName = "Anil Kumar",
                      Salary = 25000
                },
                 new Employee()
                {
                      EmpId = "12",
                      EmpName = "Mahesh",
                      Salary = 27000
                },
                  new Employee()
                {
                      EmpId = "13",
                      EmpName = "Pravinn",
                      Salary = 28000
                },
            };
        }
    }
}
