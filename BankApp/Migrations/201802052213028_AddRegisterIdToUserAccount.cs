namespace BankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegisterIdToUserAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAccounts", "RegisterId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAccounts", "RegisterId");
        }
    }
}
