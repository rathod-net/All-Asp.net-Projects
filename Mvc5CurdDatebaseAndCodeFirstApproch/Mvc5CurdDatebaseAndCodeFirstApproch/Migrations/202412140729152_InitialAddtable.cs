namespace Mvc5CurdDatebaseAndCodeFirstApproch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAddtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegisterUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(name: "User Name", nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RegisterUser");
        }
    }
}
