namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBreachHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataBreaches",
                c => new
                    {
                        DataBreachID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        UserDataBreaches_UserDataBreachesID = c.Int(),
                    })
                .PrimaryKey(t => t.DataBreachID)
                .ForeignKey("dbo.UserDataBreaches", t => t.UserDataBreaches_UserDataBreachesID, cascadeDelete: true)
                .Index(t => t.UserDataBreaches_UserDataBreachesID);
            
            CreateTable(
                "dbo.PasswordHistories",
                c => new
                    {
                        PasswordHistoryID = c.Int(nullable: false, identity: true),
                        BreachedPasswordString = c.String(),
                        DataBreachOrigin_DataBreachID = c.Int(),
                        Password_PasswordID = c.Int(),
                    })
                .PrimaryKey(t => t.PasswordHistoryID)
                .ForeignKey("dbo.DataBreaches", t => t.DataBreachOrigin_DataBreachID)
                .ForeignKey("dbo.Passwords", t => t.Password_PasswordID)
                .Index(t => t.DataBreachOrigin_DataBreachID)
                .Index(t => t.Password_PasswordID);
            
            AddColumn("dbo.CreditCards", "DataBreach_DataBreachID", c => c.Int());
            CreateIndex("dbo.CreditCards", "DataBreach_DataBreachID");
            AddForeignKey("dbo.CreditCards", "DataBreach_DataBreachID", "dbo.DataBreaches", "DataBreachID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DataBreaches", "UserDataBreaches_UserDataBreachesID", "dbo.UserDataBreaches");
            DropForeignKey("dbo.PasswordHistories", "Password_PasswordID", "dbo.Passwords");
            DropForeignKey("dbo.PasswordHistories", "DataBreachOrigin_DataBreachID", "dbo.DataBreaches");
            DropForeignKey("dbo.CreditCards", "DataBreach_DataBreachID", "dbo.DataBreaches");
            DropIndex("dbo.PasswordHistories", new[] { "Password_PasswordID" });
            DropIndex("dbo.PasswordHistories", new[] { "DataBreachOrigin_DataBreachID" });
            DropIndex("dbo.DataBreaches", new[] { "UserDataBreaches_UserDataBreachesID" });
            DropIndex("dbo.CreditCards", new[] { "DataBreach_DataBreachID" });
            DropColumn("dbo.CreditCards", "DataBreach_DataBreachID");
            DropTable("dbo.PasswordHistories");
            DropTable("dbo.DataBreaches");
        }
    }
}
