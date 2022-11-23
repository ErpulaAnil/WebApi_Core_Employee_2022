using CRUD_With_NET6_WebAPI_EntityFrameworkCore_2022.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_With_NET6_WebAPI_EntityFrameworkCore_2022.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<Student> StudentsDb { get; set; }
    }
}
