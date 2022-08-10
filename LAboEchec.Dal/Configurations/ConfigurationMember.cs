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
    public class ConfigurationMember : IEntityTypeConfiguration<Members>
    {
        public void Configure(EntityTypeBuilder<Members> builder)
        {
            builder.Property(m => m.Name).HasMaxLength(50);
            builder.HasIndex(m => m.Name).IsUnique();
            builder.HasIndex(m => m.Email).IsUnique();

        }
    }
}
