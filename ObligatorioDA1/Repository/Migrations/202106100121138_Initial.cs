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
                        UserCategoryID = c.Int(nullable: false, identity: true),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.UserCategoryID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MainPassword = c.String(),
                        UserCategories_UserCategoryID = c.Int(nullable: false),
                        UserCreditCards_UserCreditCardID = c.Int(nullable: false),
                        UserDataBreaches_UserDataBreachesID = c.Int(nullable: false),
                        UserPasswords_UserPasswordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.UserCategories", t => t.UserCategories_UserCategoryID, cascadeDelete: true)
                .ForeignKey("dbo.UserCreditCards", t => t.UserCreditCards_UserCreditCardID, cascadeDelete: true)
                .ForeignKey("dbo.UserDataBreaches", t => t.UserDataBreaches_UserDataBreachesID, cascadeDelete: true)
                .ForeignKey("dbo.UserPasswords", t => t.UserPasswords_UserPasswordID, cascadeDelete: true)
                .Index(t => t.UserCategories_UserCategoryID)
                .Index(t => t.UserCreditCards_UserCreditCardID)
                .Index(t => t.UserDataBreaches_UserDataBreachesID)
                .Index(t => t.UserPasswords_UserPasswordID);
            
            CreateTable(
                "dbo.UserCreditCards",
                c => new
                    {
                        UserCreditCardID = c.Int(nullable: false, identity: true),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.UserCreditCardID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.UserDataBreaches",
                c => new
                    {
                        UserDataBreachesID = c.Int(nullable: false, identity: true),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.UserDataBreachesID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.UserPasswords",
                c => new
                    {
                        UserPasswordID = c.Int(nullable: false, identity: true),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.UserPasswordID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCategories", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "UserPasswords_UserPasswordID", "dbo.UserPasswords");
            DropForeignKey("dbo.UserPasswords", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Passwords", "UserPassword_UserPasswordID", "dbo.UserPasswords");
            DropForeignKey("dbo.Users", "UserDataBreaches_UserDataBreachesID", "dbo.UserDataBreaches");
            DropForeignKey("dbo.UserDataBreaches", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "UserCreditCards_UserCreditCardID", "dbo.UserCreditCards");
            DropForeignKey("dbo.UserCreditCards", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.CreditCards", "UserCreditCard_UserCreditCardID", "dbo.UserCreditCards");
            DropForeignKey("dbo.Users", "UserCategories_UserCategoryID", "dbo.UserCategories");
            DropForeignKey("dbo.Categories", "UserCategory_UserCategoryID", "dbo.UserCategories");
            DropForeignKey("dbo.Passwords", "Category_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.CreditCards", "Category_CategoryID", "dbo.Categories");
            DropIndex("dbo.UserPasswords", new[] { "User_UserID" });
            DropIndex("dbo.UserDataBreaches", new[] { "User_UserID" });
            DropIndex("dbo.UserCreditCards", new[] { "User_UserID" });
            DropIndex("dbo.Users", new[] { "UserPasswords_UserPasswordID" });
            DropIndex("dbo.Users", new[] { "UserDataBreaches_UserDataBreachesID" });
            DropIndex("dbo.Users", new[] { "UserCreditCards_UserCreditCardID" });
            DropIndex("dbo.Users", new[] { "UserCategories_UserCategoryID" });
            DropIndex("dbo.UserCategories", new[] { "User_UserID" });
            DropIndex("dbo.Passwords", new[] { "UserPassword_UserPasswordID" });
            DropIndex("dbo.Passwords", new[] { "Category_CategoryID" });
            DropIndex("dbo.CreditCards", new[] { "UserCreditCard_UserCreditCardID" });
            DropIndex("dbo.CreditCards", new[] { "Category_CategoryID" });
            DropIndex("dbo.Categories", new[] { "UserCategory_UserCategoryID" });
            DropTable("dbo.UserPasswords");
            DropTable("dbo.UserDataBreaches");
            DropTable("dbo.UserCreditCards");
            DropTable("dbo.Users");
            DropTable("dbo.UserCategories");
            DropTable("dbo.Passwords");
            DropTable("dbo.CreditCards");
            DropTable("dbo.Categories");
        }
    }
}
