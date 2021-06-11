namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasswordCompleteCascade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Passwords", "UserPassword_UserPasswordID", "dbo.UserPasswords");
            DropIndex("dbo.Passwords", new[] { "UserPassword_UserPasswordID" });
            AlterColumn("dbo.Passwords", "UserPassword_UserPasswordID", c => c.Int(nullable: false));
            CreateIndex("dbo.Passwords", "UserPassword_UserPasswordID");
            AddForeignKey("dbo.Passwords", "UserPassword_UserPasswordID", "dbo.UserPasswords", "UserPasswordID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passwords", "UserPassword_UserPasswordID", "dbo.UserPasswords");
            DropIndex("dbo.Passwords", new[] { "UserPassword_UserPasswordID" });
            AlterColumn("dbo.Passwords", "UserPassword_UserPasswordID", c => c.Int());
            CreateIndex("dbo.Passwords", "UserPassword_UserPasswordID");
            AddForeignKey("dbo.Passwords", "UserPassword_UserPasswordID", "dbo.UserPasswords", "UserPasswordID");
        }
    }
}
