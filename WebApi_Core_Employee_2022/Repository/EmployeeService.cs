using WebApi_Core_Employee_2022.Data;
using WebApi_Core_Employee_2022.Models;

namespace WebApi_Core_Employee_2022.Repository
{
    public class EmployeeService:IEmployee
    {
       private  readonly EmployeeDbContext _employeeContext;

        public EmployeeService(EmployeeDbContext context)
        {
            _employeeContext = context;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeContext.EmployeesTable1.ToList();
        }
        public Employee GetEmployee(long id)
        {
            //return _employeeContext.EmployeesTable1
            //    .FirstOrDefault(e => e.EmployeeId == id);
            return _employeeContext.EmployeesTable1.Find(id);

        }
        public void DeleteEmployee(Employee employee)
        {
            _employeeContext.EmployeesTable1.Remove(employee);
            _employeeContext.SaveChanges();
        }
        public void UpdateEmployee(Employee employee, Employee employee1)
        {
            employee.FirstName = employee1.FirstName;
            employee.LastName = employee1.LastName;
            employee.Email = employee1.Email;
            employee.PhoneNumber = employee1.PhoneNumber;
            _employeeContext.SaveChanges();
        }
        public IEnumerable<Employee> AddEmployee(Employee employee)
        {
            _employeeContext.EmployeesTable1.Add(employee);
            _employeeContext.SaveChanges();
           return _employeeContext.EmployeesTable1;    
        }

    }
}
