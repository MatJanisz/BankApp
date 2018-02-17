namespace BankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdmin : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'144102d5-a547-46d4-a009-8ca5834cd970', N'admin@admin.com', 0, N'ABI1Wm4CA8NhaPs4ejskWDkUjTw6jNWAMbWnIql61Lc6kEI/yv7n2zHKt4HyWAwchA==', N'18de57f8-2c40-4ed6-922d-1160ebf92310', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'610bd26c-643d-43ec-8605-4838db2c57de', N'AdminAction')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'144102d5-a547-46d4-a009-8ca5834cd970', N'610bd26c-643d-43ec-8605-4838db2c57de')");
        }
        
        public override void Down()
        {
        }
    }
}
