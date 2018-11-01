using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Morgobot
{
    public class Server
    {
        private readonly Brain.Brain _brain;
        private readonly SettingsManager _settingsManager;
        private readonly ILogger<Server> _logger;

        public Server(Brain.Brain brain, SettingsManager settingsManager, ILogger<Server> logger)
        {
            _brain = brain;
            _settingsManager = settingsManager;
            _logger = logger;
        }

        public async Task Run()
        {
            _logger.LogInformation("Listening new messages");

            var bot = new TelegramBotClient(_settingsManager.GetSetting("botToken"));
            var offset = 0;

            while (true)
            {
                var updates = await bot.GetUpdatesAsync(offset);

                if (updates.Any())
                {
                    foreach (var update in updates)
                    {
                        if(update.Message == null)
                        {
                            _logger.LogWarning("Incoming null message.");
                            continue;
                        }

                        _logger.LogWarning($"Incoming message from {update.Message.From.FirstName} {update.Message.From.LastName} ({update.Message.From.Id}): {update.Message.Text}");

                        var charId = update.Message.Chat.Id;
                        var reply = _brain.Analyse(update);

                        try
                        {
                            var message = await bot.SendTextMessageAsync(charId, reply);
                        }
                        catch(Exception e)
                        {
                            _logger.LogError($"Can't sent message: {e.Message}");
                        }

                        offset = update.Id + 1;
                    }
                }
                else
                {
                    //_logger.LogInformation("No updates");
                }

                await Task.Delay(1000);
            }
        }
    }
}
