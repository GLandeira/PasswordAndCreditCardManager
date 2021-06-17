namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MergeMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CreditCards", "UserCreditCard_UserCreditCardID", "dbo.UserCreditCards");
            DropForeignKey("dbo.Passwords", "UserPassword_UserPasswordID", "dbo.UserPasswords");
            DropIndex("dbo.CreditCards", new[] { "UserCreditCard_UserCreditCardID" });
            DropIndex("dbo.Passwords", new[] { "UserPassword_UserPasswordID" });
            AlterColumn("dbo.CreditCards", "UserCreditCard_UserCreditCardID", c => c.Int(nullable: false));
            AlterColumn("dbo.Passwords", "UserPassword_UserPasswordID", c => c.Int(nullable: false));
            CreateIndex("dbo.CreditCards", "UserCreditCard_UserCreditCardID");
            CreateIndex("dbo.Passwords", "UserPassword_UserPasswordID");
            AddForeignKey("dbo.CreditCards", "UserCreditCard_UserCreditCardID", "dbo.UserCreditCards", "UserCreditCardID", cascadeDelete: true);
            AddForeignKey("dbo.Passwords", "UserPassword_UserPasswordID", "dbo.UserPasswords", "UserPasswordID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passwords", "UserPassword_UserPasswordID", "dbo.UserPasswords");
            DropForeignKey("dbo.CreditCards", "UserCreditCard_UserCreditCardID", "dbo.UserCreditCards");
            DropIndex("dbo.Passwords", new[] { "UserPassword_UserPasswordID" });
            DropIndex("dbo.CreditCards", new[] { "UserCreditCard_UserCreditCardID" });
            AlterColumn("dbo.Passwords", "UserPassword_UserPasswordID", c => c.Int());
            AlterColumn("dbo.CreditCards", "UserCreditCard_UserCreditCardID", c => c.Int());
            CreateIndex("dbo.Passwords", "UserPassword_UserPasswordID");
            CreateIndex("dbo.CreditCards", "UserCreditCard_UserCreditCardID");
            AddForeignKey("dbo.Passwords", "UserPassword_UserPasswordID", "dbo.UserPasswords", "UserPasswordID");
            AddForeignKey("dbo.CreditCards", "UserCreditCard_UserCreditCardID", "dbo.UserCreditCards", "UserCreditCardID");
        }
    }
}
