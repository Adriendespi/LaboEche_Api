using LaboEchec.DL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboEchec.Dal.Configurations
{
    internal class ConfigurationTournament : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            
            builder.Property(t => t.Round).HasDefaultValue(0);
            //builder.Property(t => t.Status_Tournament).HasDefaultValue(0);
        }
    }
}
