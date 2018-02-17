namespace BankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTransferSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transfers",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        NameOfTransaction = c.String(nullable: false),
                        TargetAccountNumber = c.String(nullable: false),
                        DateTransfer = c.DateTime(nullable: false),
                        TransferMoney = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transfers");
        }
    }
}
