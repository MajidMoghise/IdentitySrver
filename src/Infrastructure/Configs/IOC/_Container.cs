using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configs.IOC
{
    public static class Container
    {
        public static void RegisterIOC(IServiceCollection services, string connectionString)
        {
            DbContextRegister.ContextRegister(services,connectionString);
            Repository.Add(services);
            Application.Add(services);

        }
    }
}
