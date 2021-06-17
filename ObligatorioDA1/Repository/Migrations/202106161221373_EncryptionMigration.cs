namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EncryptionMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PasswordKeys", c => c.Binary());
            AddColumn("dbo.Users", "PasswordIV", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "PasswordIV");
            DropColumn("dbo.Users", "PasswordKeys");
        }
    }
}
