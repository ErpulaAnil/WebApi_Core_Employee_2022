using Minimal_APis_Sample.Data;
using Minimal_APis_Sample.Models;

namespace Minimal_APis_Sample.Repository
{
    public class EmployeeServices:IEmployeeService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeeServices(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IEnumerable<Employee> AddEmployee(Employee employee)
        {
            _applicationDbContext.Employees.Add(employee);
            _applicationDbContext.SaveChanges();
            return _applicationDbContext.Employees;
        }

        public bool DeleteEmployee(int id)
        {
            var emp = _applicationDbContext.Employees.FirstOrDefault(x => x.Id == id);
            if (emp is null) return false;
            _applicationDbContext.Employees.Remove(emp);
            _applicationDbContext.SaveChanges();
            return true;
        }

        public Employee GetEmployee(int id)
        {
            var emp = _applicationDbContext.Employees.FirstOrDefault(x => x.Id == id);
            if (emp is null) return null;
            return emp;
        }

        public IEnumerable<Employee> GetEmployees()
        {

           return _applicationDbContext.Employees.ToList();

         }
        

        public Employee UpdateEmployee(Employee newemployee)
        { 
                var oldemployee = _applicationDbContext.Employees.FirstOrDefault(x => x.Id == newemployee.Id);
                if (oldemployee is null) return null;

            oldemployee.EmpId = newemployee.EmpId;
            oldemployee.EmpName = newemployee.EmpName;
            oldemployee.Salary = newemployee.Salary;    

                return newemployee;
            
        }

      

        
    }
}
