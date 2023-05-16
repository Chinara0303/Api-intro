using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.SoftDelete).IsRequired().HasDefaultValue(false);
            builder.Property(e => e.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(e => e.ModifyAt).IsRequired().HasDefaultValue(DateTime.Now);
        }
    }
}
