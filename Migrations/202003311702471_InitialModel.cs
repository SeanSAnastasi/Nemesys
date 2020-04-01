namespace Nemesys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvestigationModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReporterId = c.Int(nullable: false),
                        ReportId = c.Int(nullable: false),
                        InvestigatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvestigatorModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Username = c.String(),
                        ActiveInvestigations = c.Int(nullable: false),
                        TotalInvestigations = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReporterModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Username = c.String(),
                        ActiveReports = c.Int(nullable: false),
                        HandledReports = c.Int(nullable: false),
                        PendingReports = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReporterModels");
            DropTable("dbo.InvestigatorModels");
            DropTable("dbo.InvestigationModels");
        }
    }
}
