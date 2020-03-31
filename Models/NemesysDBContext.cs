using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Nemesys.Models
{
    public class NemesysDBContext:DbContext
    {
        public NemesysDBContext()
        {

        }
        public DbSet<InvestigationModel> InvestigationModel { get; set; }
        public DbSet<InvestigatorModel> InvestigatorModel { get; set; }
        public DbSet<ReporterModel> ReporterModel { get; set; }

    }
}
