namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepositoryTestsNotWorking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Password_PasswordID", c => c.Int());
            CreateIndex("dbo.Users", "Password_PasswordID");
            AddForeignKey("dbo.Users", "Password_PasswordID", "dbo.Passwords", "PasswordID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Password_PasswordID", "dbo.Passwords");
            DropIndex("dbo.Users", new[] { "Password_PasswordID" });
            DropColumn("dbo.Users", "Password_PasswordID");
        }
    }
}
