namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "User_UserID", "dbo.Users");
            DropIndex("dbo.Categories", new[] { "User_UserID" });
            CreateTable(
                "dbo.UserCategories",
                c => new
                    {
                        UserCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserCategoryID)
                .ForeignKey("dbo.Users", t => t.UserCategoryID)
                .Index(t => t.UserCategoryID);
            
            AddColumn("dbo.Categories", "UserCategory_UserCategoryID", c => c.Int());
            CreateIndex("dbo.Categories", "UserCategory_UserCategoryID");
            AddForeignKey("dbo.Categories", "UserCategory_UserCategoryID", "dbo.UserCategories", "UserCategoryID");
            DropColumn("dbo.Categories", "User_UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "User_UserID", c => c.Int());
            DropForeignKey("dbo.UserCategories", "UserCategoryID", "dbo.Users");
            DropForeignKey("dbo.Categories", "UserCategory_UserCategoryID", "dbo.UserCategories");
            DropIndex("dbo.UserCategories", new[] { "UserCategoryID" });
            DropIndex("dbo.Categories", new[] { "UserCategory_UserCategoryID" });
            DropColumn("dbo.Categories", "UserCategory_UserCategoryID");
            DropTable("dbo.UserCategories");
            CreateIndex("dbo.Categories", "User_UserID");
            AddForeignKey("dbo.Categories", "User_UserID", "dbo.Users", "UserID");
        }
    }
}
