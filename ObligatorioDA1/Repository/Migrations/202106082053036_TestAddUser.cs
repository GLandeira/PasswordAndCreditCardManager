namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestAddUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Passwords",
                c => new
                    {
                        PasswordID = c.Int(nullable: false, identity: true),
                        PasswordString = c.String(),
                        Site = c.String(),
                        Username = c.String(),
                        LastModification = c.DateTime(nullable: false),
                        SecurityLevel = c.Int(nullable: false),
                        Notes = c.String(),
                        Category_CategoryID = c.Int(),
                        UserPassword_ID = c.Int(),
                    })
                .PrimaryKey(t => t.PasswordID)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryID)
                .ForeignKey("dbo.UserPasswords", t => t.UserPassword_ID)
                .Index(t => t.Category_CategoryID)
                .Index(t => t.UserPassword_ID);
            
            CreateTable(
                "dbo.UserCreditCards",
                c => new
                    {
                        ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.UserPasswords",
                c => new
                    {
                        ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MainPassword = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            AddColumn("dbo.Categories", "User_UserID", c => c.Int());
            AddColumn("dbo.CreditCards", "UserCreditCard_ID", c => c.Int());
            CreateIndex("dbo.Categories", "User_UserID");
            CreateIndex("dbo.CreditCards", "UserCreditCard_ID");
            AddForeignKey("dbo.CreditCards", "UserCreditCard_ID", "dbo.UserCreditCards", "ID");
            AddForeignKey("dbo.Categories", "User_UserID", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPasswords", "ID", "dbo.Users");
            DropForeignKey("dbo.UserCreditCards", "ID", "dbo.Users");
            DropForeignKey("dbo.Categories", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Passwords", "UserPassword_ID", "dbo.UserPasswords");
            DropForeignKey("dbo.CreditCards", "UserCreditCard_ID", "dbo.UserCreditCards");
            DropForeignKey("dbo.Passwords", "Category_CategoryID", "dbo.Categories");
            DropIndex("dbo.UserPasswords", new[] { "ID" });
            DropIndex("dbo.UserCreditCards", new[] { "ID" });
            DropIndex("dbo.Passwords", new[] { "UserPassword_ID" });
            DropIndex("dbo.Passwords", new[] { "Category_CategoryID" });
            DropIndex("dbo.CreditCards", new[] { "UserCreditCard_ID" });
            DropIndex("dbo.Categories", new[] { "User_UserID" });
            DropColumn("dbo.CreditCards", "UserCreditCard_ID");
            DropColumn("dbo.Categories", "User_UserID");
            DropTable("dbo.Users");
            DropTable("dbo.UserPasswords");
            DropTable("dbo.UserCreditCards");
            DropTable("dbo.Passwords");
        }
    }
}
