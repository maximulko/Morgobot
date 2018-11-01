using System.Runtime.InteropServices;
using Morgobot.Brain.Grammar;
using Morgobot.Brain.Movements;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Morgobot.Brain
{
    public class Brain
    {
        private readonly BasicAnalyzer _basicThoughts;
        private readonly MovementAnalyzer _movementThoughts;
        private readonly Huefication _huefication;
        private readonly ServiceMessageAnalysis _serviceMessageAnalysis;

        public Brain(BasicAnalyzer basicThoughts, MovementAnalyzer movementThoughts, Huefication huefication, ServiceMessageAnalysis serviceMessageAnalysis)
        {
            _basicThoughts = basicThoughts;
            _movementThoughts = movementThoughts;
            _huefication = huefication;
            _serviceMessageAnalysis = serviceMessageAnalysis;
        }

        public string Analyse(Update update)
        {
            if (update.Message.Type == MessageType.ServiceMessage)
            {
                return _serviceMessageAnalysis.Analyse(update);
            }

            var message = update.Message.Text;

            if (message == null)
            {
                return null;
            }

            message = message.ToLower();

            if (message.StartsWith("/"))
            {
                message = message.Substring(1, message.Length - 1);
            }

            message = message.Replace('ё', 'е');

            var phrase = new Phrase(message);

            return _movementThoughts.Analyse(phrase)
                ?? _basicThoughts.Analyse(phrase)
                ?? _huefication.Analyse(phrase)
                ?? "Иди нахуй!";
        }
    }
}
