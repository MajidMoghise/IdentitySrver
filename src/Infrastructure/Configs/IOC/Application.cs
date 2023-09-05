using Application.Contract.Applications;
using Application.User;
using Microsoft.Extensions.DependencyInjection;

namespace Configs.IOC
{
    internal class Application

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
            services.AddTransient<IUserTokenService, UserTokenService>();
        }
    }
}
