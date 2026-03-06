using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);

            builder.Property(c => c.CategoryId)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Slug)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasIndex(c => c.Slug)
                .IsUnique();

            builder.Property(c => c.Icon)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(c => c.IsShown)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(c => c.MetaTitle)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.MetaDescription)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(c => c.ParentCategoryId);

            // Self-referencing ilişki (Ana & Alt Kategori)
            builder.HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            // BaseEntity fields
            builder.Property(c => c.CreatedDate)
                .IsRequired();

            builder.Property(c => c.CreatedBy)
                .HasMaxLength(100);

            builder.Property(c => c.UpdatedDate);

            builder.Property(c => c.UpdatedBy)
                .HasMaxLength(100);

            builder.Property(c => c.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(c => c.DeletedDate);

            builder.Property(c => c.DeletedBy)
                .HasMaxLength(100);

            builder.Property(c => c.RowVersion)
                .IsRowVersion();

            builder.HasQueryFilter(c => !c.IsDeleted);

            builder.ToTable("Categories");
        }
    }
}
