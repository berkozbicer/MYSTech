using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId);

            builder.Property(x => x.ProductName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.Slug)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.HasIndex(x => x.Slug).IsUnique();

            builder.Property(x => x.Price)
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.DiscountPrice)
                   .HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.ProductImages)
                   .WithOne(p => p.Product)
                   .HasForeignKey(p => p.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.ProductFeatures)
                   .WithOne(p => p.Product)
                   .HasForeignKey(p => x.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
