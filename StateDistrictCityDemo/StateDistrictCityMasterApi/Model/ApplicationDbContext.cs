using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace StateDistrictCityMasterApi.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        {
        }
        public DbSet<State> States { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<District> Districts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            
        }
    }
}
