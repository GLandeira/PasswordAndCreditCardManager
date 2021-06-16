namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TEst : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PasswordKeys", c => c.String());
            AddColumn("dbo.Users", "PasswordIV", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "PasswordIV");
            DropColumn("dbo.Users", "PasswordKeys");
        }
    }
}
