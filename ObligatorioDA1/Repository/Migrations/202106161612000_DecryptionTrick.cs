namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DecryptionTrick : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Passwords", "UserPassword_UserPasswordID", "dbo.UserPasswords");
            DropIndex("dbo.Passwords", new[] { "UserPassword_UserPasswordID" });
            AddColumn("dbo.Passwords", "UserPassword_UserPasswordID1", c => c.Int(nullable: false));
            AlterColumn("dbo.Passwords", "UserPassword_UserPasswordID", c => c.Int());
            CreateIndex("dbo.Passwords", "UserPassword_UserPasswordID");
            CreateIndex("dbo.Passwords", "UserPassword_UserPasswordID1");
            AddForeignKey("dbo.Passwords", "UserPassword_UserPasswordID", "dbo.UserPasswords", "UserPasswordID");
            AddForeignKey("dbo.Passwords", "UserPassword_UserPasswordID1", "dbo.UserPasswords", "UserPasswordID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passwords", "UserPassword_UserPasswordID1", "dbo.UserPasswords");
            DropForeignKey("dbo.Passwords", "UserPassword_UserPasswordID", "dbo.UserPasswords");
            DropIndex("dbo.Passwords", new[] { "UserPassword_UserPasswordID1" });
            DropIndex("dbo.Passwords", new[] { "UserPassword_UserPasswordID" });
            AlterColumn("dbo.Passwords", "UserPassword_UserPasswordID", c => c.Int(nullable: false));
            DropColumn("dbo.Passwords", "UserPassword_UserPasswordID1");
            CreateIndex("dbo.Passwords", "UserPassword_UserPasswordID");
            AddForeignKey("dbo.Passwords", "UserPassword_UserPasswordID", "dbo.UserPasswords", "UserPasswordID", cascadeDelete: true);
        }
    }
}
