using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Telegram.Bot;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Morgobot.Web.Controllers
{
    [Route("[controller]")]
    public class DebugController : Controller
    {
        private readonly TelegramBotClient _telegramBotClient;

        public DebugController(TelegramBotClient telegramBotClient)
        {
            _telegramBotClient = telegramBotClient ?? throw new ArgumentNullException(nameof(telegramBotClient));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var webhookInfo = await _telegramBotClient.GetWebhookInfoAsync();
            return Ok(webhookInfo);
        }
    }
}
