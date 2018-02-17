namespace BankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredToUserAccount : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserAccounts", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.UserAccounts", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.UserAccounts", "AccoutNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAccounts", "AccoutNumber", c => c.String());
            AlterColumn("dbo.UserAccounts", "Surname", c => c.String());
            AlterColumn("dbo.UserAccounts", "Name", c => c.String());
        }
    }
}
