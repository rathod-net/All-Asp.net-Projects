using DAL.DataEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBContextEntity
{
    public class LibraryDBContext : DbContext
    {
        public LibraryDBContext() : base("name=LibManagementDB") 
        { 
        
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<CategoryBook> CategoryBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasIndex(b => b.ISBN)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
