using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Morgobot.Brain;
using Morgobot.Brain.Grammar;
using Morgobot.Brain.Movements;

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
                .AddSingleton<BasicThoughts>()
                .AddSingleton<MovementThoughts>()
                .AddSingleton<Huefication>()
                .AddSingleton<ServiceMessageAnalysis>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}