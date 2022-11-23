using BulkyBookWeb_With_MVC_6._0_BLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb_With_MVC_6._0_BLayer.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
       public DbSet<Category> CategoriesBulky { get; set; }
    }
}
