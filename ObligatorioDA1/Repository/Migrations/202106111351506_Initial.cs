namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserCategory_UserCategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.UserCategories", t => t.UserCategory_UserCategoryID)
                .Index(t => t.UserCategory_UserCategoryID);
            
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        CreditCardID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        Number = c.String(),
                        SecurityCode = c.String(),
                        ValidDue = c.DateTime(nullable: false),
                        Notes = c.String(),
                        Category_CategoryID = c.Int(),
                        UserCreditCard_UserCreditCardID = c.Int(),
                    })
                .PrimaryKey(t => t.CreditCardID)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryID)
                .ForeignKey("dbo.UserCreditCards", t => t.UserCreditCard_UserCreditCardID)
                .Index(t => t.Category_CategoryID)
                .Index(t => t.UserCreditCard_UserCreditCardID);
            
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
                        UserPassword_UserPasswordID = c.Int(),
                    })
                .PrimaryKey(t => t.PasswordID)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryID)
                .ForeignKey("dbo.UserPasswords", t => t.UserPassword_UserPasswordID)
                .Index(t => t.Category_CategoryID)
                .Index(t => t.UserPassword_UserPasswordID);
            
            CreateTable(
                "dbo.UserCategories",
                c => new
                    {
                        UserCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserCategoryID)
                .ForeignKey("dbo.Users", t => t.UserCategoryID, cascadeDelete: true)
                .Index(t => t.UserCategoryID);
            
            CreateTable(
                "dbo.UserCreditCards",
                c => new
                    {
                        UserCreditCardID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserCreditCardID)
                .ForeignKey("dbo.Users", t => t.UserCreditCardID, cascadeDelete: true)
                .Index(t => t.UserCreditCardID);
            
            CreateTable(
                "dbo.UserDataBreaches",
                c => new
                    {
                        UserDataBreachesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserDataBreachesID)
                .ForeignKey("dbo.Users", t => t.UserDataBreachesID, cascadeDelete: true)
                .Index(t => t.UserDataBreachesID);
            
            CreateTable(
                "dbo.UserPasswords",
                c => new
                    {
                        UserPasswordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserPasswordID)
                .ForeignKey("dbo.Users", t => t.UserPasswordID, cascadeDelete: true)
                .Index(t => t.UserPasswordID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MainPassword = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPasswords", "UserPasswordID", "dbo.Users");
            DropForeignKey("dbo.UserDataBreaches", "UserDataBreachesID", "dbo.Users");
            DropForeignKey("dbo.UserCreditCards", "UserCreditCardID", "dbo.Users");
            DropForeignKey("dbo.UserCategories", "UserCategoryID", "dbo.Users");
            DropForeignKey("dbo.Passwords", "UserPassword_UserPasswordID", "dbo.UserPasswords");
            DropForeignKey("dbo.CreditCards", "UserCreditCard_UserCreditCardID", "dbo.UserCreditCards");
            DropForeignKey("dbo.Categories", "UserCategory_UserCategoryID", "dbo.UserCategories");
            DropForeignKey("dbo.Passwords", "Category_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.CreditCards", "Category_CategoryID", "dbo.Categories");
            DropIndex("dbo.UserPasswords", new[] { "UserPasswordID" });
            DropIndex("dbo.UserDataBreaches", new[] { "UserDataBreachesID" });
            DropIndex("dbo.UserCreditCards", new[] { "UserCreditCardID" });
            DropIndex("dbo.UserCategories", new[] { "UserCategoryID" });
            DropIndex("dbo.Passwords", new[] { "UserPassword_UserPasswordID" });
            DropIndex("dbo.Passwords", new[] { "Category_CategoryID" });
            DropIndex("dbo.CreditCards", new[] { "UserCreditCard_UserCreditCardID" });
            DropIndex("dbo.CreditCards", new[] { "Category_CategoryID" });
            DropIndex("dbo.Categories", new[] { "UserCategory_UserCategoryID" });
            DropTable("dbo.Users");
            DropTable("dbo.UserPasswords");
            DropTable("dbo.UserDataBreaches");
            DropTable("dbo.UserCreditCards");
            DropTable("dbo.UserCategories");
            DropTable("dbo.Passwords");
            DropTable("dbo.CreditCards");
            DropTable("dbo.Categories");
        }
    }
}
