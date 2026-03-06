using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Configurations
{
    public class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasKey(pf => pf.ProductFeatureId);

            builder.Property(pf => pf.ProductFeatureId)
                .ValueGeneratedOnAdd();

            builder.Property(pf => pf.Key)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(pf => pf.Value)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(pf => pf.Product)
                .WithMany(p => p.ProductFeatures)
                .HasForeignKey(pf => pf.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // BaseEntity fields
            builder.Property(pf => pf.CreatedDate)
                .IsRequired();

            builder.Property(pf => pf.CreatedBy)
                .HasMaxLength(100);

            builder.Property(pf => pf.UpdatedDate);

            builder.Property(pf => pf.UpdatedBy)
                .HasMaxLength(100);

            builder.Property(pf => pf.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(pf => pf.DeletedDate);

            builder.Property(pf => pf.DeletedBy)
                .HasMaxLength(100);

            builder.Property(pf => pf.RowVersion)
                .IsRowVersion();

            builder.HasQueryFilter(pf => !pf.IsDeleted);

            builder.ToTable("ProductFeatures");
        }
    }
}
