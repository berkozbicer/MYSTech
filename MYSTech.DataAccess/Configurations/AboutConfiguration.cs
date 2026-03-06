using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Configurations
{
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.HasKey(a => a.AboutId);

            builder.Property(a => a.AboutId)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(a => a.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            // BaseEntity fields
            builder.Property(a => a.CreatedDate)
                .IsRequired();

            builder.Property(a => a.CreatedBy)
                .HasMaxLength(100);

            builder.Property(a => a.UpdatedDate);

            builder.Property(a => a.UpdatedBy)
                .HasMaxLength(100);

            builder.Property(a => a.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(a => a.DeletedDate);

            builder.Property(a => a.DeletedBy)
                .HasMaxLength(100);

            builder.Property(a => a.RowVersion)
                .IsRowVersion();

            builder.HasQueryFilter(a => !a.IsDeleted);

            builder.ToTable("Abouts");
        }
    }
}
