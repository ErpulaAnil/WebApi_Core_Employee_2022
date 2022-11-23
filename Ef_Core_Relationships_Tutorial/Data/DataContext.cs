using Microsoft.EntityFrameworkCore;

namespace Ef_Core_Relationships_Tutorial.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<User> UsersTable { get; set; } 
        public DbSet<Character> Characters { get; set; } 
    }
}
