namespace BankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTypeAccount : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TypeAccounts(Fee,Type) VALUES(20,'normal')");
            Sql("INSERT INTO TypeAccounts(Fee,Type) VALUES(5,'student')");
            Sql("INSERT INTO TypeAccounts(Fee,Type) VALUES(0,'junior')");
        }
        
        public override void Down()
        {
        }
    }
}
