namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DecryptionTrickIgnore : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Passwords", "UserPassword_UserPasswordID", "dbo.UserPasswords");
            DropIndex("dbo.Passwords", new[] { "UserPassword_UserPasswordID" });
            DropIndex("dbo.Passwords", new[] { "UserPassword_UserPasswordID1" });
            DropColumn("dbo.Passwords", "UserPassword_UserPasswordID");
            RenameColumn(table: "dbo.Passwords", name: "UserPassword_UserPasswordID1", newName: "UserPassword_UserPasswordID");
            AlterColumn("dbo.Passwords", "UserPassword_UserPasswordID", c => c.Int(nullable: false));
            CreateIndex("dbo.Passwords", "UserPassword_UserPasswordID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Passwords", new[] { "UserPassword_UserPasswordID" });
            AlterColumn("dbo.Passwords", "UserPassword_UserPasswordID", c => c.Int());
            RenameColumn(table: "dbo.Passwords", name: "UserPassword_UserPasswordID", newName: "UserPassword_UserPasswordID1");
            AddColumn("dbo.Passwords", "UserPassword_UserPasswordID", c => c.Int());
            CreateIndex("dbo.Passwords", "UserPassword_UserPasswordID1");
            CreateIndex("dbo.Passwords", "UserPassword_UserPasswordID");
            AddForeignKey("dbo.Passwords", "UserPassword_UserPasswordID", "dbo.UserPasswords", "UserPasswordID");
        }
    }
}
