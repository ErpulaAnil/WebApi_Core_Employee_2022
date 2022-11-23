using Microsoft.EntityFrameworkCore;
using Minimal_APis_Sample.Models;

namespace Minimal_APis_Sample.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
