namespace BankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUsers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO UserAccounts(Name,Surname,Money,TypeAccountId,DateOfBirth) "+
                "VALUES('John','Kowalski',3000,1,'01/02/1979')");
            Sql("INSERT INTO UserAccounts(Name,Surname,Money,TypeAccountId,DateOfBirth) " +
               "VALUES('Andrew','Smith',10000,2,'06/05/2005')");
            Sql("INSERT INTO UserAccounts(Name,Surname,Money,TypeAccountId,DateOfBirth) " +
               "VALUES('Cameron','Rodriguez',1000,3,'09/12/1999')");
        }
        
        public override void Down()
        {
        }
    }
}
