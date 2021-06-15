namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryDeleteCascade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "UserCategory_UserCategoryID", "dbo.UserCategories");
            DropIndex("dbo.Categories", new[] { "UserCategory_UserCategoryID" });
            AlterColumn("dbo.Categories", "UserCategory_UserCategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Categories", "UserCategory_UserCategoryID");
            AddForeignKey("dbo.Categories", "UserCategory_UserCategoryID", "dbo.UserCategories", "UserCategoryID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "UserCategory_UserCategoryID", "dbo.UserCategories");
            DropIndex("dbo.Categories", new[] { "UserCategory_UserCategoryID" });
            AlterColumn("dbo.Categories", "UserCategory_UserCategoryID", c => c.Int());
            CreateIndex("dbo.Categories", "UserCategory_UserCategoryID");
            AddForeignKey("dbo.Categories", "UserCategory_UserCategoryID", "dbo.UserCategories", "UserCategoryID");
        }
    }
}
