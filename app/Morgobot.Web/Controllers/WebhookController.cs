using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Morgobot.Web.Infrastructure;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Morgobot.Web.Controllers
{
    [Route("[controller]")]
    public class WebhookController : Controller
    {
        private readonly Morgobot.Brain.Brain _brain;
        private readonly TelegramBotClient _client;
        private readonly ILogger<WebhookController> _logger;
        private readonly PerChatCache _perChatCache;

        private const string CurrentContextCacheKey = "CurrentContext";

        public WebhookController(
            Morgobot.Brain.Brain brain, 
            TelegramBotClient client,
            ILogger<WebhookController> logger,
            PerChatCache perChatCache)
        {
            _brain = brain ?? throw new ArgumentNullException(nameof(brain));
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _perChatCache = perChatCache ?? throw new ArgumentNullException(nameof(perChatCache));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            if (update == null)
            {
                _logger.LogWarning("Incoming null update.");
                return BadRequest();
            }

            if (update.Message == null)
            {
                // It looks like this is some regular case for telegram.
                // So Ok should be returned
                _logger.LogWarning("Incoming null message.");
                return Ok();
            }

            _logger.LogInformation($"Incoming message from {update.Message.From.FirstName} {update.Message.From.LastName} ({update.Message.From.Id}): {update.Message.Text}");

            var chatId = update.Message.Chat.Id;
            var context = _perChatCache.Get<string>(CurrentContextCacheKey, chatId);
            var reply = _brain.Analyse(update.Message.Text, chatId, update.Message.Type, context);

            if (reply.ClenUpCurrentContext)
            {
                _perChatCache.Set<string>(CurrentContextCacheKey, chatId, null);
            }

            var message = await _client.SendTextMessageAsync(chatId, reply.Text);

            return NoContent();
        }
    }
}
