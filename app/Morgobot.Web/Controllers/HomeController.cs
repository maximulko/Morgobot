using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Morgobot.Web.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly TelegramBotClient _client;

        public HomeController(TelegramBotClient client)
        {
            _client = client ?? throw new System.ArgumentNullException(nameof(client));
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
