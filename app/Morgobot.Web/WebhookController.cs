using Microsoft.AspNetCore.Mvc;
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

        public WebhookController(Brain.Brain brain, TelegramBotClient client)
        {
            _brain = brain ?? throw new System.ArgumentNullException(nameof(brain));
            _client = client ?? throw new System.ArgumentNullException(nameof(client));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            if (update == null)
                return BadRequest();

            var chatId = update.Message.Chat.Id;
            var reply = _brain.Analyse(update);
            var message = await _client.SendTextMessageAsync(chatId, reply);

            return Ok();
        }
    }
}
