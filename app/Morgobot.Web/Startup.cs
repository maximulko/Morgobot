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
        private readonly ILogger<Startup> _logger;

        public Startup(
            IServiceProvider serviceProvider, 
            IConfiguration configuration,
            ILogger<Startup> logger)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));      
        }    

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

        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory,
            IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            loggerFactory.AddApplicationInsights(app.ApplicationServices, LogLevel.Information);

            applicationLifetime.ApplicationStarted.Register(OnStarted);
        }

        private void OnStarted()
        {
            _logger.LogInformation("Setting up web hook..");
            SetWebhook(_configuration.GetSection("telegram").Get<TelegramOptions>()).GetAwaiter().GetResult();
            _logger.LogInformation("Finished");
        }

        private async Task SetWebhook(TelegramOptions telegramOptions)
        {
            var bot = new TelegramBotClient(telegramOptions.BotToken);
            await bot.SetWebhookAsync(telegramOptions.WebHookUrl);
        }
    }
}
