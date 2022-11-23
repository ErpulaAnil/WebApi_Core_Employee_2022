using WebApi_MultipleClasses_with_GenericT.Data;
using WebApi_MultipleClasses_with_GenericT.Models;

namespace WebApi_MultipleClasses_with_GenericT.Repository
{
    public class RepositoryConstructor:RepositoryService<Employee>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public RepositoryConstructor(ApplicationDbContext applicationDbContext):base(applicationDbContext)
        {

        }
    }



    public class StudentConstructor : RepositoryService<Student>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public StudentConstructor(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }



    public class CustomerConstructor : RepositoryService<Customer>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomerConstructor(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
