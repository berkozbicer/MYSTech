using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasKey(pi => pi.ProductImageId);

            builder.Property(pi => pi.ProductImageId)
                .ValueGeneratedOnAdd();

            builder.Property(pi => pi.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(pi => pi.IsMain)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(pi => pi.Order)
                .IsRequired()
                .HasDefaultValue(0);

            builder.HasOne(pi => pi.Product)
                .WithMany(p => p.ProductImages)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // BaseEntity fields
            builder.Property(pi => pi.CreatedDate)
                .IsRequired();

            builder.Property(pi => pi.CreatedBy)
                .HasMaxLength(100);

            builder.Property(pi => pi.UpdatedDate);

            builder.Property(pi => pi.UpdatedBy)
                .HasMaxLength(100);

            builder.Property(pi => pi.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(pi => pi.DeletedDate);

            builder.Property(pi => pi.DeletedBy)
                .HasMaxLength(100);

            builder.Property(pi => pi.RowVersion)
                .IsRowVersion();

            builder.HasQueryFilter(pi => !pi.IsDeleted);

            builder.ToTable("ProductImages");
        }
    }
}
