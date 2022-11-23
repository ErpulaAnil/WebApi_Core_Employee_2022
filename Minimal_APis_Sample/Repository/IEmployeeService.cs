using Minimal_APis_Sample.Models;

namespace Minimal_APis_Sample.Repository
{
    public interface IEmployeeService
    {

      IEnumerable<Employee> AddEmployee(Employee employee);

        Employee GetEmployee(int id);

        IEnumerable<Employee> GetEmployees();

        Employee UpdateEmployee(Employee newemployee);

        bool DeleteEmployee(int id);
    }
}
