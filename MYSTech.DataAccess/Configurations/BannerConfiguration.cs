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
            builder.HasKey(b => b.BannerId);

            builder.Property(b => b.BannerId)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.SubTitle)
                .IsRequired()
                .HasMaxLength(400);

            builder.Property(b => b.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(b => b.MobileImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(b => b.ButtonText)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.ButtonLink)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(b => b.Order)
                .IsRequired();

            builder.Property(b => b.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(b => b.VideoUrl)
                .HasMaxLength(500);

            builder.Property(b => b.BackgroundColor)
                .HasMaxLength(50);

            // BaseEntity fields
            builder.Property(b => b.CreatedDate)
                .IsRequired();

            builder.Property(b => b.CreatedBy)
                .HasMaxLength(100);

            builder.Property(b => b.UpdatedDate);

            builder.Property(b => b.UpdatedBy)
                .HasMaxLength(100);

            builder.Property(b => b.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(b => b.DeletedDate);

            builder.Property(b => b.DeletedBy)
                .HasMaxLength(100);

            builder.Property(b => b.RowVersion)
                .IsRowVersion();

            builder.HasQueryFilter(b => !b.IsDeleted);

            builder.ToTable("Banners");
        }
    }
}
