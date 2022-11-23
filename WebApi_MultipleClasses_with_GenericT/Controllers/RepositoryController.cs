using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_MultipleClasses_with_GenericT.Models;
using WebApi_MultipleClasses_with_GenericT.Repository;

namespace WebApi_MultipleClasses_with_GenericT.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class EmployeeController :AllController<Employee, RepositoryConstructor>
    {
        public EmployeeController(RepositoryConstructor repositoryConstructor):base(repositoryConstructor)    
        {
                
        }
    }


    public class StudentController : AllController<Student, StudentConstructor>
    {
        public StudentController(StudentConstructor studentConstructor) : base(studentConstructor)
        {

        }
    }



    public class CustomerController : AllController<Customer, CustomerConstructor>
    {
        public CustomerController(CustomerConstructor customerController) : base(customerController)
        {

        }
    }
}
