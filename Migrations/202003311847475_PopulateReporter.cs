namespace Nemesys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateReporter : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Reporters(Email,Password,Username,ActiveReports,HandledReports,PendingReports,ProfileImage) VALUES ('john@example.com','password123','John',0,0,0,0)");
        }
        
        public override void Down()
        {
        }
    }
}
