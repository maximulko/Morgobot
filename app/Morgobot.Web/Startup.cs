using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Morgobot.Brain;
using Morgobot.Brain.Movements;
using System;
using Telegram.Bot;

namespace Morgobot.Web
{
    public class Startup
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;

        public Startup(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            var bot = new TelegramBotClient("332048837:AAGhg7B4skR3r_Q1w1XNbFPUvl6E2KmpUok");
            bot.SetWebhookAsync("https://morgobot-web.azurewebsites.net/webhook");
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddLogging(opt =>
            {
                opt.AddConsole();
                opt.AddAzureWebAppDiagnostics();
            });

            services
                .AddSingleton<Brain.Brain>()
                .AddSingleton(factory => {
                    var telegramOptions = factory.GetService<IOptions<TelegramOptions>>();
                    return new TelegramBotClient(telegramOptions.Value.BotToken);
                })
                .AddSingleton<ServiceMessageAnalysis>()
                .AddSingleton<IAnalyzer, BasicAnalyzer>()
                .AddSingleton<IAnalyzer, MovementAnalyzer>()
                .AddSingleton<IAnalyzer, Huefication>();

            services.Configure<TelegramOptions>(_configuration.GetSection("telegram"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
