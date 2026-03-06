using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Configurations
{
    public class TestimonialConfiguration : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.HasKey(t => t.TestimonialId);

            builder.Property(t => t.TestimonialId)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.TestimonialName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(t => t.TestimonialDescription)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(t => t.TestimonialImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(t => t.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            // BaseEntity fields
            builder.Property(t => t.CreatedDate)
                .IsRequired();

            builder.Property(t => t.CreatedBy)
                .HasMaxLength(100);

            builder.Property(t => t.UpdatedDate);

            builder.Property(t => t.UpdatedBy)
                .HasMaxLength(100);

            builder.Property(t => t.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(t => t.DeletedDate);

            builder.Property(t => t.DeletedBy)
                .HasMaxLength(100);

            builder.Property(t => t.RowVersion)
                .IsRowVersion();

            builder.HasQueryFilter(t => !t.IsDeleted);

            builder.ToTable("Testimonials");
        }
    }
}
