namespace Login_Registration_FormUsingCodeFirstApproch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(name: "First Name", nullable: false, maxLength: 50, unicode: false),
                        LastName = c.String(name: "Last Name", nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
