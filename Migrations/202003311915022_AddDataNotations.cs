namespace Nemesys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataNotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Investigators", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Investigators", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Investigators", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Reporters", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Reporters", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Reporters", "Username", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reporters", "Username", c => c.String());
            AlterColumn("dbo.Reporters", "Password", c => c.String());
            AlterColumn("dbo.Reporters", "Email", c => c.String());
            AlterColumn("dbo.Investigators", "Username", c => c.String());
            AlterColumn("dbo.Investigators", "Password", c => c.String());
            AlterColumn("dbo.Investigators", "Email", c => c.String());
        }
    }
}
