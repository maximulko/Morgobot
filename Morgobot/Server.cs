using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Morgobot
{
    public class Server
    {
        private Brain.Brain _brain;
        private SettingsManager _settingsManager;

        public Server(Brain.Brain brain, SettingsManager settingsManager)
        {
            _brain = brain;
            _settingsManager = settingsManager;
        }

        public async Task Run()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Listening new messages");

            var bot = new TelegramBotClient(_settingsManager.GetSetting("botToken"));
            var offset = 0;

            while (true)
            {
                var updates = await bot.GetUpdatesAsync(offset);

                if (updates.Any())
                {
                    foreach (var update in updates)
                    {
                        Console.WriteLine($"Incoming message from {update.Message.From.FirstName} {update.Message.From.LastName}: {update.Message.Text}");

                        var charId = update.Message.Chat.Id;
                        var reply = _brain.Analyse(update.Message.Text);
                        var message = await bot.SendTextMessageAsync(charId, reply);
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
