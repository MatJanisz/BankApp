namespace BankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Fee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        AccoutNumber = c.String(),
                        Money = c.Int(nullable: false),
                        TypeAccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeAccounts", t => t.TypeAccountId, cascadeDelete: true)
                .Index(t => t.TypeAccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAccounts", "TypeAccountId", "dbo.TypeAccounts");
            DropIndex("dbo.UserAccounts", new[] { "TypeAccountId" });
            DropTable("dbo.UserAccounts");
            DropTable("dbo.TypeAccounts");
        }
    }
}
