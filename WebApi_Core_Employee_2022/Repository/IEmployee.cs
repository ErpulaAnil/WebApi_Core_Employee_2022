using WebApi_Core_Employee_2022.Models;

namespace WebApi_Core_Employee_2022.Repository
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(long id);
        void DeleteEmployee(Employee employee);
        IEnumerable<Employee> AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee, Employee employee1);
    }
}
