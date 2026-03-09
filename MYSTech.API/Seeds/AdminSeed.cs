using Microsoft.AspNetCore.Identity;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Seeds
{
    public static class AdminSeed
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // ── Roller ────────────────────────────────────────────────────
            var roles = new[] { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // ── Admin Kullanıcı ───────────────────────────────────────────
            const string adminEmail = "admin@mystech.com";
            const string adminPassword = "Admin123!";

            var existingAdmin = await userManager.FindByEmailAsync(adminEmail);
            if (existingAdmin == null)
            {
                var admin = new AppUser
                {
                    FirstName = "MYSTech",
                    LastName = "Admin",
                    UserName = "mystech_admin",
                    Email = adminEmail,
                    EmailConfirmed = true,
                    IsActive = true
                };

                var result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
