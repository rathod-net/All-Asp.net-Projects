using Microsoft.EntityFrameworkCore;
using MVC8_Core_Demos.Models.Entities;

namespace MVC8_Core_Demos.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}