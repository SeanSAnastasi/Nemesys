using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
namespace Nemesys.Models
{
    public class NemesysDBContext:DbContext
    {
        public NemesysDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Investigation> Investigation { get; set; }
        public DbSet<Investigator> Investigator { get; set; }
        public DbSet<Reporter> Reporter { get; set; }
        public DbSet<Report> Report { get; set; }


    }
}
