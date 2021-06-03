namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestCategoriesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            AddColumn("dbo.CreditCards", "CreditCardID", c => c.Int(nullable: false));
            AddColumn("dbo.CreditCards", "Category_CategoryID", c => c.Int());
            CreateIndex("dbo.CreditCards", "Category_CategoryID");
            AddForeignKey("dbo.CreditCards", "Category_CategoryID", "dbo.Categories", "CategoryID");
            DropColumn("dbo.CreditCards", "Category_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CreditCards", "Category_Name", c => c.String());
            DropForeignKey("dbo.CreditCards", "Category_CategoryID", "dbo.Categories");
            DropIndex("dbo.CreditCards", new[] { "Category_CategoryID" });
            DropColumn("dbo.CreditCards", "Category_CategoryID");
            DropColumn("dbo.CreditCards", "CreditCardID");
            DropTable("dbo.Categories");
        }
    }
}
