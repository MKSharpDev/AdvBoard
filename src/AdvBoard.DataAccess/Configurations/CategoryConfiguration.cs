using AdvBoard.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.DataAccess.Configurations
{
    public class CategoryConfiguration: IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(5000).IsRequired();
            builder.Property(x => x.Number).HasMaxLength(100).IsRequired();

            builder.HasMany(x => x.Adverts).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).IsRequired().OnDelete(DeleteBehavior.SetNull);
        }
    }
}
