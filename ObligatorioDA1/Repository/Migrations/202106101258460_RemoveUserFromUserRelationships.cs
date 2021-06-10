namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserFromUserRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserCreditCards", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.UserDataBreaches", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.UserPasswords", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.UserCategories", "User_UserID", "dbo.Users");
            DropIndex("dbo.UserCategories", new[] { "User_UserID" });
            DropIndex("dbo.UserCreditCards", new[] { "User_UserID" });
            DropIndex("dbo.UserDataBreaches", new[] { "User_UserID" });
            DropIndex("dbo.UserPasswords", new[] { "User_UserID" });
            DropColumn("dbo.UserCategories", "User_UserID");
            DropColumn("dbo.UserCreditCards", "User_UserID");
            DropColumn("dbo.UserDataBreaches", "User_UserID");
            DropColumn("dbo.UserPasswords", "User_UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserPasswords", "User_UserID", c => c.Int());
            AddColumn("dbo.UserDataBreaches", "User_UserID", c => c.Int());
            AddColumn("dbo.UserCreditCards", "User_UserID", c => c.Int());
            AddColumn("dbo.UserCategories", "User_UserID", c => c.Int());
            CreateIndex("dbo.UserPasswords", "User_UserID");
            CreateIndex("dbo.UserDataBreaches", "User_UserID");
            CreateIndex("dbo.UserCreditCards", "User_UserID");
            CreateIndex("dbo.UserCategories", "User_UserID");
            AddForeignKey("dbo.UserCategories", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.UserPasswords", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.UserDataBreaches", "User_UserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.UserCreditCards", "User_UserID", "dbo.Users", "UserID");
        }
    }
}
