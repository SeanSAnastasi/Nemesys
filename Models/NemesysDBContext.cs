using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nemesys.Areas.Identity.Data;

namespace Nemesys.Models
{
    public class NemesysDBContext: IdentityDbContext<User>
    {
        
        public NemesysDBContext(DbContextOptions<NemesysDBContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            
        }
        public DbSet<Investigation> Investigation { get; set; }
        public DbSet<Investigator> Investigator { get; set; }
        public DbSet<Reporter> Reporter { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Like> Like { get; set; }

        


    }
}
