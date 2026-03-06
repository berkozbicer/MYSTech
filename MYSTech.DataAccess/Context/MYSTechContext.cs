using Microsoft.EntityFrameworkCore;
using MYSTech.DataAccess.Configurations;
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
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MYSTechContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}