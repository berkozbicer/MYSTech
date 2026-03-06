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
            builder.HasKey(x => x.ProductFeatureId);

            builder.Property(x => x.Key)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(x => x.Value)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.HasOne(x => x.Product)
                   .WithMany(p => p.ProductFeatures)
                   .HasForeignKey(x => x.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
