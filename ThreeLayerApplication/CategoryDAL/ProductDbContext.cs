using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryDAL
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext() : base("name=CategoryDb")
        {

        }
        public DbSet<Category> categories { get; set; }
    }
}
