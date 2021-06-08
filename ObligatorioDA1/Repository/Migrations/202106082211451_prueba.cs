namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prueba : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CreditCards", name: "UserCreditCard_ID", newName: "UserCreditCard_UserCreditCardID");
            RenameColumn(table: "dbo.Passwords", name: "UserPassword_ID", newName: "UserPassword_UserPasswordID");
            RenameColumn(table: "dbo.UserCreditCards", name: "ID", newName: "UserCreditCardID");
            RenameColumn(table: "dbo.UserPasswords", name: "ID", newName: "UserPasswordID");
            RenameIndex(table: "dbo.CreditCards", name: "IX_UserCreditCard_ID", newName: "IX_UserCreditCard_UserCreditCardID");
            RenameIndex(table: "dbo.Passwords", name: "IX_UserPassword_ID", newName: "IX_UserPassword_UserPasswordID");
            RenameIndex(table: "dbo.UserCreditCards", name: "IX_ID", newName: "IX_UserCreditCardID");
            RenameIndex(table: "dbo.UserPasswords", name: "IX_ID", newName: "IX_UserPasswordID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserPasswords", name: "IX_UserPasswordID", newName: "IX_ID");
            RenameIndex(table: "dbo.UserCreditCards", name: "IX_UserCreditCardID", newName: "IX_ID");
            RenameIndex(table: "dbo.Passwords", name: "IX_UserPassword_UserPasswordID", newName: "IX_UserPassword_ID");
            RenameIndex(table: "dbo.CreditCards", name: "IX_UserCreditCard_UserCreditCardID", newName: "IX_UserCreditCard_ID");
            RenameColumn(table: "dbo.UserPasswords", name: "UserPasswordID", newName: "ID");
            RenameColumn(table: "dbo.UserCreditCards", name: "UserCreditCardID", newName: "ID");
            RenameColumn(table: "dbo.Passwords", name: "UserPassword_UserPasswordID", newName: "UserPassword_ID");
            RenameColumn(table: "dbo.CreditCards", name: "UserCreditCard_UserCreditCardID", newName: "UserCreditCard_ID");
        }
    }
}
