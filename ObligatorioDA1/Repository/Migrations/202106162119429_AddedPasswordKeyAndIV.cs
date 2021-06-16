namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPasswordKeyAndIV : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Passwords", "PasswordIV", c => c.String());
            AddColumn("dbo.Passwords", "PasswordKey", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Passwords", "PasswordKey");
            DropColumn("dbo.Passwords", "PasswordIV");
        }
    }
}
