namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixPasswordUserPasswordRelationshipProblem : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Passwords", new[] { "UserPassword_UserPasswordID" });
            AlterColumn("dbo.Passwords", "UserPassword_UserPasswordID", c => c.Int());
            CreateIndex("dbo.Passwords", "UserPassword_UserPasswordID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Passwords", new[] { "UserPassword_UserPasswordID" });
            AlterColumn("dbo.Passwords", "UserPassword_UserPasswordID", c => c.Int(nullable: false));
            CreateIndex("dbo.Passwords", "UserPassword_UserPasswordID");
        }
    }
}
