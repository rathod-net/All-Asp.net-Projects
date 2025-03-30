using DAL.DataEntities;
using System.Data.Entity;

namespace DAL.DbContextEntity
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(): base("name=NewProductDb")
        {

        }
       
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Product> Products { get; set; }
    }
}
