namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTestCategoriesAdded : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CreditCards");
            AlterColumn("dbo.CreditCards", "Number", c => c.String());
            AlterColumn("dbo.CreditCards", "CreditCardID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CreditCards", "CreditCardID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CreditCards");
            AlterColumn("dbo.CreditCards", "CreditCardID", c => c.Int(nullable: false));
            AlterColumn("dbo.CreditCards", "Number", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.CreditCards", "Number");
        }
    }
}
