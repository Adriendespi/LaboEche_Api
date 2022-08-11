using LaboEchec.Dal.Configurations;
using LaboEchec.DL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboEchec.DL
{
    public class LaboEchecContext : DbContext
    {
        public DbSet<Members> Members { get; set; }
        public DbSet<Tournament> tournaments { get; set; }
        public LaboEchecContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ConfigurationMember());
            builder.ApplyConfiguration(new ConfigurationTournament());

        }
    }
}
