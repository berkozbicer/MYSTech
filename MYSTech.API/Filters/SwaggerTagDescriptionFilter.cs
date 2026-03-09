using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MYSTech.API.Filters
{
    public class SwaggerTagDescriptionFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Tags = new HashSet<OpenApiTag>
            {
                new() { Name = "Abouts",          Description = "Hakkında sayfası içerik yönetimi" },
                new() { Name = "Banners",         Description = "Ana sayfa banner yönetimi" },
                new() { Name = "BlogCategories",  Description = "Blog kategorileri yönetimi" },
                new() { Name = "Blogs",           Description = "Blog yazıları yönetimi" },
                new() { Name = "Categories",      Description = "Ürün kategorileri yönetimi" },
                new() { Name = "Contacts",        Description = "İletişim mesajları yönetimi" },
                new() { Name = "Products",        Description = "Ürün yönetimi" },
                new() { Name = "ProductImages",   Description = "Ürün görselleri yönetimi" },
                new() { Name = "ProductFeatures", Description = "Ürün özellikleri yönetimi" },
                new() { Name = "SocialMedias",    Description = "Sosyal medya bağlantıları yönetimi" },
                new() { Name = "Testimonials",    Description = "Referans/yorum yönetimi" },
            };
        }
    }
}