using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(c => c.ContactId);

            builder.Property(c => c.ContactId)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.FullName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Phone)
                .HasMaxLength(50);

            builder.Property(c => c.Subject)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(c => c.Message)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.CreatedBy).HasMaxLength(100);
            builder.Property(c => c.UpdatedDate);
            builder.Property(c => c.UpdatedBy).HasMaxLength(100);
            builder.Property(c => c.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.Property(c => c.DeletedDate);
            builder.Property(c => c.DeletedBy).HasMaxLength(100);
            builder.Property(c => c.RowVersion).IsRowVersion();

            builder.HasQueryFilter(c => !c.IsDeleted);
            builder.ToTable("Contacts");
        }
    }
}
