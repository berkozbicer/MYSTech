using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Configurations
{
    public class BannerConfiguration : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.HasKey(x => x.BannerId);

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.SubTitle)
                   .HasMaxLength(500);

            builder.Property(x => x.ButtonText)
                   .HasMaxLength(50);

            builder.Property(x => x.ButtonLink)
                   .HasMaxLength(250);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
