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
            builder.HasKey(p => p.ProductId);

            builder.Property(p => p.ProductId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(p => p.Slug)
                .IsRequired()
                .HasMaxLength(300);

            builder.HasIndex(p => p.Slug)
                .IsUnique();

            builder.Property(p => p.ShortDescription)
                .HasMaxLength(500);

            builder.Property(p => p.FullDescription)
                .IsRequired();

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.DiscountPrice)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.StockQuantity)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.IsHomeShown)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(p => p.MetaTitle)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.MetaDescription)
                .HasMaxLength(500);

            builder.Property(p => p.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.ProductImages)
                .WithOne(pi => pi.Product)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.ProductFeatures)
                .WithOne(pf => pf.Product)
                .HasForeignKey(pf => pf.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // BaseEntity fields
            builder.Property(p => p.CreatedDate)
                .IsRequired();

            builder.Property(p => p.CreatedBy)
                .HasMaxLength(100);

            builder.Property(p => p.UpdatedDate);

            builder.Property(p => p.UpdatedBy)
                .HasMaxLength(100);

            builder.Property(p => p.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(p => p.DeletedDate);

            builder.Property(p => p.DeletedBy)
                .HasMaxLength(100);

            builder.Property(p => p.RowVersion)
                .IsRowVersion();

            builder.HasQueryFilter(p => !p.IsDeleted);

            builder.ToTable("Products");
        }
    }
}
