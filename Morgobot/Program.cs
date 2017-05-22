using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

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
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Listening new messages");

            var conf = new JsonConfigurationProvider(new JsonConfigurationSource());
            conf.Load(new FileStream("appSettings.json", FileMode.Open));
            string botToken;
            conf.TryGet("botToken", out botToken);


            var bot = new TelegramBotClient(botToken);
            var offset = 0;

            while (true)
            {
                var updates = await bot.GetUpdatesAsync(offset);

                if (updates.Any())
                {
                    foreach(var update in updates)
                    {
                        Console.WriteLine($"Incoming message from {update.Message.From.FirstName} {update.Message.From.LastName}: {update.Message.Text}");

                        var charId = update.Message.Chat.Id;
                        var message = await bot.SendTextMessageAsync(charId, "Иди нахуй!");
                        offset = update.Id + 1;
                    }
                }
                else
                {
                    //Console.WriteLine("No updates");
                }

                await Task.Delay(1000);
            }
        }
    }
}