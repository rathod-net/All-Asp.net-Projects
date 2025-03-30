namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreatedatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 8000, unicode: false),
                        ISBN = c.String(nullable: false, maxLength: 8000, unicode: false),
                        PublicationName = c.String(name: "Publication Name", nullable: false, maxLength: 8000, unicode: false),
                        AuthorName = c.String(name: "Author Name", nullable: false, maxLength: 8000, unicode: false),
                        CreatedBy = c.String(name: "Created By", nullable: false, maxLength: 8000, unicode: false),
                        CreatedDate = c.DateTime(name: "Created Date", nullable: false),
                        CategoryBookId = c.Int(name: "Category Book Id", nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryBooks", t => t.CategoryBookId, cascadeDelete: true)
                .Index(t => t.ISBN, unique: true)
                .Index(t => t.CategoryBookId);
            
            CreateTable(
                "dbo.CategoryBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryType = c.String(name: "Category Type", nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "Category Book Id", "dbo.CategoryBooks");
            DropIndex("dbo.Book", new[] { "Category Book Id" });
            DropIndex("dbo.Book", new[] { "ISBN" });
            DropTable("dbo.CategoryBooks");
            DropTable("dbo.Book");
        }
    }
}
