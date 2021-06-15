namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredRelationshipDBPH : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PasswordHistories", "DataBreach_DataBreachID", "dbo.DataBreaches");
            DropIndex("dbo.PasswordHistories", new[] { "DataBreach_DataBreachID" });
            AlterColumn("dbo.PasswordHistories", "DataBreach_DataBreachID", c => c.Int(nullable: false));
            CreateIndex("dbo.PasswordHistories", "DataBreach_DataBreachID");
            AddForeignKey("dbo.PasswordHistories", "DataBreach_DataBreachID", "dbo.DataBreaches", "DataBreachID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PasswordHistories", "DataBreach_DataBreachID", "dbo.DataBreaches");
            DropIndex("dbo.PasswordHistories", new[] { "DataBreach_DataBreachID" });
            AlterColumn("dbo.PasswordHistories", "DataBreach_DataBreachID", c => c.Int());
            CreateIndex("dbo.PasswordHistories", "DataBreach_DataBreachID");
            AddForeignKey("dbo.PasswordHistories", "DataBreach_DataBreachID", "dbo.DataBreaches", "DataBreachID");
        }
    }
}
