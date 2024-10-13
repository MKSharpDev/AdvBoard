using AdvBoard.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.DataAccess.Configurations
{
    public class AdvConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();
        }
    }
}
