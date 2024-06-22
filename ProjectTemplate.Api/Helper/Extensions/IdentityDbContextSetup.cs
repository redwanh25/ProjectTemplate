using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Infrastructure.Context;
using static ProjectTemplate.Model.Entity.IdentityModels;

namespace ProjectTemplate.Api.Helper.Extensions;

public static class IdentityDbContextSetup
{
    public static void AddIdentityDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("Database"));
        });

        services.AddIdentity<ApplicationUser, ApplicationRole>(options => {
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
        }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
    }
}
