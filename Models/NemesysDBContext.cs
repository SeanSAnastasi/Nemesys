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
        public DbSet<Investigation> Investigation { get; set; }
        public DbSet<Investigator> Investigator { get; set; }
        public DbSet<Reporter> ReporterModel { get; set; }

    }
}
