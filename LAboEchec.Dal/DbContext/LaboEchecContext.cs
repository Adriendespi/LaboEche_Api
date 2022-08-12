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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=tfnsdotde0407b;Initial Catalog=LaboEchec ;User ID=StudentAdmin;Password=123456a.;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ConfigurationMember());
            builder.ApplyConfiguration(new ConfigurationTournament());

        }
    }
}
