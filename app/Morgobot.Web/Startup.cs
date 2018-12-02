using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Morgobot.Brain;
using Morgobot.Brain.Movements;
using Telegram.Bot;

namespace Morgobot.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddLogging(opt =>
            {
                opt.AddConsole();
            });

            services
                .AddSingleton<Brain.Brain>()
                .AddSingleton(factory =>
                {
                    return new TelegramBotClient("332048837:AAGhg7B4skR3r_Q1w1XNbFPUvl6E2KmpUok");
                })
                .AddSingleton<ServiceMessageAnalysis>()
                .AddSingleton<IAnalyzer, BasicAnalyzer>()
                .AddSingleton<IAnalyzer, MovementAnalyzer>()
                .AddSingleton<IAnalyzer, Huefication>();
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
