using Domain.Contract.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Repositories;
using Persistance.Repositories.Action;
using Persistance.Repositories.User;

namespace Configs.IOC
{
    internal static class Repository

    {
        public static void Add(IServiceCollection services)
        {
            AddScoped(services);
            AddSingleton(services);
            AddTransient(services);
        }
        private static void AddScoped(IServiceCollection services)
        {
        }
        private static void AddSingleton(IServiceCollection services)
        {
        }
        private static void AddTransient(IServiceCollection services)
        {

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IActionRepository, ActionRepository>();
            services.AddTransient<IUserRepository, UserRepository>();


        }

    }

}
