using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Morgobot.Brain;
using Morgobot.Brain.Movements;
using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Morgobot.Web
{
    public class Startup
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;

        public Startup(IServiceProvider serviceProvider, IConfiguration configuration, ILogger<Startup> logger)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            logger.LogInformation("Setting up web hook..");
            SetWebhook(_configuration.GetSection("telegram").Get<TelegramOptions>()).GetAwaiter().GetResult();
            logger.LogInformation("Finished");
        }

        private async Task SetWebhook(TelegramOptions telegramOptions)
        {
            var bot = new TelegramBotClient(telegramOptions.BotToken);
            await bot.DeleteWebhookAsync();
            await bot.SetWebhookAsync(telegramOptions.WebHookUrl);
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
                .AddSingleton<IAnalyzer, Huefication>()
                .AddSingleton<IAnalyzer, GoogleAnalyzer>();

            services.Configure<TelegramOptions>(_configuration.GetSection("telegram"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            loggerFactory.AddApplicationInsights(app.ApplicationServices, LogLevel.Information);
        }
    }
}
