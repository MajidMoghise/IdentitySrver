using EFDBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Configs.IOC
{
    internal static class DbContextRegister
    {
        public static void ContextRegister(this IServiceCollection services, string ConnectionString)
        {
            services.AddDbContext<IdentityServerDbContext>(options =>
                                options.UseSqlServer(ConnectionString));
        }
    }
}
