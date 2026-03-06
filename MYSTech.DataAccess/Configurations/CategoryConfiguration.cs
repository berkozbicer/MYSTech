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
            builder.HasKey(x => x.CategoryId);

            builder.Property(x => x.CategoryName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(x => x.Slug)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasIndex(x => x.Slug).IsUnique();

            builder.HasOne(x => x.ParentCategory)
                   .WithMany(x => x.SubCategories)
                   .HasForeignKey(x => x.ParentCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
