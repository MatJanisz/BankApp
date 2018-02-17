namespace BankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeRequiredFromAccountNumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserAccounts", "AccoutNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAccounts", "AccoutNumber", c => c.String(nullable: false));
        }
    }
}
