namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditCardDomainChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CreditCards", "UserCreditCard_UserCreditCardID", "dbo.UserCreditCards");
            DropIndex("dbo.CreditCards", new[] { "UserCreditCard_UserCreditCardID" });
            AlterColumn("dbo.CreditCards", "UserCreditCard_UserCreditCardID", c => c.Int(nullable: false));
            CreateIndex("dbo.CreditCards", "UserCreditCard_UserCreditCardID");
            AddForeignKey("dbo.CreditCards", "UserCreditCard_UserCreditCardID", "dbo.UserCreditCards", "UserCreditCardID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditCards", "UserCreditCard_UserCreditCardID", "dbo.UserCreditCards");
            DropIndex("dbo.CreditCards", new[] { "UserCreditCard_UserCreditCardID" });
            AlterColumn("dbo.CreditCards", "UserCreditCard_UserCreditCardID", c => c.Int());
            CreateIndex("dbo.CreditCards", "UserCreditCard_UserCreditCardID");
            AddForeignKey("dbo.CreditCards", "UserCreditCard_UserCreditCardID", "dbo.UserCreditCards", "UserCreditCardID");
        }
    }
}
