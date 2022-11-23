using Microsoft.EntityFrameworkCore;
using WebApi_MultipleClasses_with_GenericT.Models;

namespace WebApi_MultipleClasses_with_GenericT.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Customer> Customers { get; set; }


    }
}
