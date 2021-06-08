namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class TestAddUserWithUserDataBreaches : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDataBreaches",
                c => new
                    {
                        UserDataBreachesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserDataBreachesID)
                .ForeignKey("dbo.Users", t => t.UserDataBreachesID)
                .Index(t => t.UserDataBreachesID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDataBreaches", "UserDataBreachesID", "dbo.Users");
            DropIndex("dbo.UserDataBreaches", new[] { "UserDataBreachesID" });
            DropTable("dbo.UserDataBreaches");
        }
    }
}
