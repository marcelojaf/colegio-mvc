using Colegio.App.Extensions;
using Colegio.Data.Context;
using Microsoft.AspNetCore.Identity;

namespace Colegio.App.Configurations
{
    /// <summary>
    /// Classe de configuração do Identity
    /// </summary>
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ColegioDbContext>()
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
