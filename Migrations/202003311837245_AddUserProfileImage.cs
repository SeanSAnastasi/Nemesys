namespace Nemesys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserProfileImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Investigators", "ProfileImage", c => c.Binary());
            AddColumn("dbo.Reporters", "ProfileImage", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reporters", "ProfileImage");
            DropColumn("dbo.Investigators", "ProfileImage");
        }
    }
}
