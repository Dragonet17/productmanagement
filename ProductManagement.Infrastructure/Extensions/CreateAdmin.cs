using System;
using System.Threading.Tasks;
using ApplicationIdentity.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Database.Database;
using ProductManagement.Infrastructure.Consts;
using ProductManagement.Infrastructure.Models;

namespace ProductManagement.Infrastructure.Extensions
{
    public static class CreateAdmin
    {
        public static async Task CreateUserWithAdminRole(this IApplicationBuilder app, IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var admin = new Admin();
            configuration.GetSection(nameof(Admin)).Bind(admin);
            if (string.IsNullOrWhiteSpace(admin.Email)
                || string.IsNullOrWhiteSpace(admin.Password))
            {
                admin = Admin.GetDefaultAdmin();
            }
             
            var user = await userManager.FindByEmailAsync(admin.Email);
            if (user != null)
                return;

            var roleCheck = await roleManager.RoleExistsAsync(Roles.Admin);
            if (!roleCheck)
            {
                await roleManager.CreateAsync(new ApplicationRole(Roles.Admin));
            }

            var newAdmin = new ApplicationUser()
            {
                Email = admin.Email,
                UserName = Roles.Admin
            };

            var result = await userManager.CreateAsync(newAdmin, admin.Password);
            if (result.Succeeded)
            {
                user = await userManager.FindByEmailAsync(admin.Email);
                await userManager.AddToRoleAsync(user, Roles.Admin);
            }
        }
    }
}
