namespace CURDUsingCodeFirstApprochDemoAndValidation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "FirstName", newName: "First Name");
            AlterColumn("dbo.Users", "First Name", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Users", "Age", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Age", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "First Name", c => c.String());
            RenameColumn(table: "dbo.Users", name: "First Name", newName: "FirstName");
        }
    }
}
