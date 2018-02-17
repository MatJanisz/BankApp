namespace BankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateofBirthToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAccounts", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAccounts", "DateOfBirth");
        }
    }
}
