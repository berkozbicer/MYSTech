using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Configurations
{
    public class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.HasKey(s => s.SocialMediaId);

            builder.Property(s => s.SocialMediaId)
                .ValueGeneratedOnAdd();

            builder.Property(s => s.Icon)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.Url)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            // BaseEntity fields
            builder.Property(s => s.CreatedDate)
                .IsRequired();

            builder.Property(s => s.CreatedBy)
                .HasMaxLength(100);

            builder.Property(s => s.UpdatedDate);

            builder.Property(s => s.UpdatedBy)
                .HasMaxLength(100);

            builder.Property(s => s.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(s => s.DeletedDate);

            builder.Property(s => s.DeletedBy)
                .HasMaxLength(100);

            builder.Property(s => s.RowVersion)
                .IsRowVersion();

            builder.HasQueryFilter(s => !s.IsDeleted);

            builder.ToTable("SocialMedias");
        }
    }
}
