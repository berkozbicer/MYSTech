using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(b => b.BlogId);

            builder.Property(b => b.BlogId)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(b => b.Slug)
                .IsRequired()
                .HasMaxLength(300);

            builder.HasIndex(b => b.Slug)
                .IsUnique();

            builder.Property(b => b.ShortDescription)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(b => b.Content)
                .IsRequired();

            builder.Property(b => b.CoverImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(b => b.ThumbnailUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(b => b.ReadingTime)
                .IsRequired();

            builder.Property(b => b.MetaDescription)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(b => b.IsPublished)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(b => b.BlogCategory)
                .WithMany(bc => bc.Blogs)
                .HasForeignKey(b => b.BlogCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

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

            builder.ToTable("Blogs");
        }
    }
}
