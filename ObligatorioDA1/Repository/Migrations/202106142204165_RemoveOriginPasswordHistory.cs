namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveOriginPasswordHistory : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PasswordHistories", name: "DataBreachOrigin_DataBreachID", newName: "DataBreach_DataBreachID");
            RenameIndex(table: "dbo.PasswordHistories", name: "IX_DataBreachOrigin_DataBreachID", newName: "IX_DataBreach_DataBreachID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PasswordHistories", name: "IX_DataBreach_DataBreachID", newName: "IX_DataBreachOrigin_DataBreachID");
            RenameColumn(table: "dbo.PasswordHistories", name: "DataBreach_DataBreachID", newName: "DataBreachOrigin_DataBreachID");
        }
    }
}
