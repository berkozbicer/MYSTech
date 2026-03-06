using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Configurations
{
    public class BlogCategoryConfiguration : IEntityTypeConfiguration<BlogCategory>
    {
        public void Configure(EntityTypeBuilder<BlogCategory> builder)
        {
            builder.HasKey(bc => bc.BlogCategoryId);

            builder.Property(bc => bc.BlogCategoryId)
                .ValueGeneratedOnAdd();

            builder.Property(bc => bc.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(bc => bc.Slug)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasIndex(bc => bc.Slug)
                .IsUnique();

            builder.Property(bc => bc.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(bc => bc.IconUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(bc => bc.DisplayOrder)
                .IsRequired();

            builder.Property(bc => bc.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasMany(bc => bc.Blogs)
                .WithOne(b => b.BlogCategory)
                .HasForeignKey(b => b.BlogCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // BaseEntity fields
            builder.Property(bc => bc.CreatedDate)
                .IsRequired();

            builder.Property(bc => bc.CreatedBy)
                .HasMaxLength(100);

            builder.Property(bc => bc.UpdatedDate);

            builder.Property(bc => bc.UpdatedBy)
                .HasMaxLength(100);

            builder.Property(bc => bc.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(bc => bc.DeletedDate);

            builder.Property(bc => bc.DeletedBy)
                .HasMaxLength(100);

            builder.Property(bc => bc.RowVersion)
                .IsRowVersion();

            builder.HasQueryFilter(bc => !bc.IsDeleted);

            builder.ToTable("BlogCategories");
        }
    }
}
