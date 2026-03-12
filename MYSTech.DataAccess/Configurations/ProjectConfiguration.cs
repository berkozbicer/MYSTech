using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.ProjectId);

            builder.Property(x => x.ProjectName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasMaxLength(250);

            builder.HasIndex(x => x.Slug)
                .IsUnique();

            builder.Property(x => x.ShortDescription)
                .HasMaxLength(500);

            builder.Property(x => x.Description)
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.ImageUrl)
                .HasMaxLength(500);

            builder.Property(x => x.ClientName)
                .HasMaxLength(200);

            builder.Property(x => x.ProjectUrl)
                .HasMaxLength(500);

            builder.Property(x => x.Technologies)
                .HasMaxLength(500);

            builder.Property(x => x.Category)
                .HasMaxLength(200);

            builder.Property(x => x.Order)
                .HasDefaultValue(1);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.Property(x => x.MetaTitle)
                .HasMaxLength(250);

            builder.Property(x => x.MetaDescription)
                .HasMaxLength(500);

            builder.Property(x => x.CompletedDate)
                .IsRequired();

            builder.ToTable("Projects");
        }
    }
}
