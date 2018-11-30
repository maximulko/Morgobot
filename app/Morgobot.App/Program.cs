using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Morgobot.Brain;
using Morgobot.Brain.Movements;
using System;
using System.Threading.Tasks;

namespace Morgobot.App
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
                .AddSingleton<ServiceMessageAnalysis>()
                .AddSingleton<IAnalyzer, BasicAnalyzer>()
                .AddSingleton<IAnalyzer, MovementAnalyzer>()
                .AddSingleton<IAnalyzer, Huefication>()
                .AddLogging(opt =>
                {
                    opt.AddConsole();
                    opt.AddLog4Net();
                })
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}