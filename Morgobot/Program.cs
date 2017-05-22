using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Morgobot
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            var serviceProvider = CreateServiceProvider();

            var server = serviceProvider.GetService<Server>();
            await server.Run();
        }

        static IServiceProvider CreateServiceProvider()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<Brain.Brain>()
                .AddSingleton<Server>()
                .AddSingleton<SettingsManager>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}