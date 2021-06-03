namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        Number = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        SecurityCode = c.String(),
                        ValidDue = c.DateTime(nullable: false),
                        Category_Name = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Number);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CreditCards");
        }
    }
}
