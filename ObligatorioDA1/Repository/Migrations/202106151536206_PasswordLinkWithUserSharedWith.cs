namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasswordLinkWithUserSharedWith : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PasswordUsers",
                c => new
                    {
                        Password_PasswordID = c.Int(nullable: false),
                        User_UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Password_PasswordID, t.User_UserID })
                .ForeignKey("dbo.Passwords", t => t.Password_PasswordID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.Password_PasswordID)
                .Index(t => t.User_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PasswordUsers", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.PasswordUsers", "Password_PasswordID", "dbo.Passwords");
            DropIndex("dbo.PasswordUsers", new[] { "User_UserID" });
            DropIndex("dbo.PasswordUsers", new[] { "Password_PasswordID" });
            DropTable("dbo.PasswordUsers");
        }
    }
}
