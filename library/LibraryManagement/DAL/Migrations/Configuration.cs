namespace DAL.Migrations
{
    using DAL.DataEntity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.DBContextEntity.LibraryDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DAL.DBContextEntity.LibraryDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.CategoryBooks.AddOrUpdate(
            c => c.CategoryType, // Prevent duplicate seed data
            new CategoryBook { CategoryType = "Mystery" },
            new CategoryBook { CategoryType = "Horror" },
            new CategoryBook { CategoryType = "Science fiction" },
            new CategoryBook { CategoryType = "Thriller" },
            new CategoryBook { CategoryType = "History" }
        );
            context.SaveChanges();
        }
    }
}
