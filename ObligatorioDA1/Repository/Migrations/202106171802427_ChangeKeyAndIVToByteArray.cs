namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeKeyAndIVToByteArray : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Passwords", "PasswordIV", c => c.Binary());
            AddColumn("dbo.Passwords", "PasswordKey", c => c.Binary());
            AlterColumn("dbo.Users", "PasswordKeys", c => c.Binary());
            AlterColumn("dbo.Users", "PasswordIV", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "PasswordIV", c => c.String());
            AlterColumn("dbo.Users", "PasswordKeys", c => c.String());
            DropColumn("dbo.Passwords", "PasswordKey");
            DropColumn("dbo.Passwords", "PasswordIV");
        }
    }
}
