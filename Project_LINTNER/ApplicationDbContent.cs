using Microsoft.EntityFrameworkCore;
using Project_LINTNER.Models;

namespace Project_LINTNER
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        {
            

        }


    }
}
