using Microsoft.EntityFrameworkCore;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Context
{
    public class MYSTechContext : DbContext
    {
        public MYSTechContext(DbContextOptions<MYSTechContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<Banner> Banners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // PRODUCT
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.ProductId);

                entity.Property(x => x.ProductName)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(x => x.Slug)
                      .IsRequired()
                      .HasMaxLength(250);

                entity.HasIndex(x => x.Slug)
                      .IsUnique();

                entity.Property(x => x.Price)
                      .HasColumnType("decimal(18,2)");

                entity.Property(x => x.DiscountPrice)
                      .HasColumnType("decimal(18,2)");

                entity.HasOne(x => x.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(x => x.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(x => x.ProductImages)
                      .WithOne(p => p.Product)
                      .HasForeignKey(p => p.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(x => x.ProductFeatures)
                      .WithOne(p => p.Product)
                      .HasForeignKey(p => p.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasQueryFilter(x => !x.IsDeleted);
            });

            // CATEGORY
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(x => x.CategoryId);

                entity.Property(x => x.CategoryName)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(x => x.Slug)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.HasIndex(x => x.Slug)
                      .IsUnique();

                entity.HasOne(x => x.ParentCategory)
                      .WithMany(x => x.SubCategories)
                      .HasForeignKey(x => x.ParentCategoryId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasQueryFilter(x => !x.IsDeleted);
            });

            // PRODUCT IMAGE
            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasKey(x => x.ProductImageId);

                entity.Property(x => x.ImageUrl)
                      .IsRequired()
                      .HasMaxLength(500);

                entity.HasOne(x => x.Product)
                      .WithMany(p => p.ProductImages)
                      .HasForeignKey(x => x.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasQueryFilter(x => !x.IsDeleted);
            });

            // PRODUCT FEATURE
            modelBuilder.Entity<ProductFeature>(entity =>
            {
                entity.HasKey(x => x.ProductFeatureId);

                entity.Property(x => x.Key)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(x => x.Value)
                      .IsRequired()
                      .HasMaxLength(500);

                entity.HasOne(x => x.Product)
                      .WithMany(p => p.ProductFeatures)
                      .HasForeignKey(x => x.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasQueryFilter(x => !x.IsDeleted);
            });

            // BANNER
            modelBuilder.Entity<Banner>(entity =>
            {
                entity.HasKey(x => x.BannerId);

                entity.Property(x => x.Title)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(x => x.SubTitle)
                      .HasMaxLength(500);

                entity.Property(x => x.ButtonText)
                      .HasMaxLength(50);

                entity.Property(x => x.ButtonLink)
                      .HasMaxLength(250);

                entity.HasQueryFilter(x => !x.IsDeleted);
            });
        }
    }
}
