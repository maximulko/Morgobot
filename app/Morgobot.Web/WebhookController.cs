using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Morgobot.Web
{
    [Route("[controller]")]
    public class WebhookController : Controller
    {
        private readonly Brain.Brain _brain;
        private readonly TelegramBotClient _client;
        private readonly ILogger<WebhookController> _logger;

        public WebhookController(
            Brain.Brain brain, 
            TelegramBotClient client,
            ILogger<WebhookController> logger)
        {
            _brain = brain ?? throw new System.ArgumentNullException(nameof(brain));
            _client = client ?? throw new System.ArgumentNullException(nameof(client));
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            if (update == null || update.Message == null)
            {
                _logger.LogWarning("Incoming null message.");
                return BadRequest();
            }

            _logger.LogInformation($"Incoming message from {update.Message.From.FirstName} {update.Message.From.LastName} ({update.Message.From.Id}): {update.Message.Text}");

            var chatId = update.Message.Chat.Id;
            var reply = _brain.Analyse(update);
            var message = await _client.SendTextMessageAsync(chatId, reply);

            return Ok();
        }
    }
}
