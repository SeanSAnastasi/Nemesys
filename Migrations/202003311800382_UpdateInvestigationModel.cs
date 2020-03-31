namespace Nemesys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInvestigationModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.InvestigationModels", newName: "Investigations");
            RenameTable(name: "dbo.InvestigatorModels", newName: "Investigators");
            RenameTable(name: "dbo.ReporterModels", newName: "Reporters");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Reporters", newName: "ReporterModels");
            RenameTable(name: "dbo.Investigators", newName: "InvestigatorModels");
            RenameTable(name: "dbo.Investigations", newName: "InvestigationModels");
        }
    }
}
