using Morgobot.Brain.Grammar;
using Morgobot.Brain.Movements;

namespace Morgobot.Brain
{
    public class Brain
    {
        private readonly BasicThoughts _basicThoughts;
        private readonly MovementThoughts _movementThoughts;
        private readonly Huefication _huefication;

        public Brain(BasicThoughts basicThoughts, MovementThoughts movementThoughts, Huefication huefication)
        {
            _basicThoughts = basicThoughts;
            _movementThoughts = movementThoughts;
            _huefication = huefication;
        }

        public string Analyse(string message, int fromId)
        {
            if (message == null)
            {
                return null;
            }

            message = message.ToLower();

            if (message.StartsWith("/"))
            {
                message = message.Substring(1, message.Length - 1);
            }

            var phrase = new Phrase(message);

            return _movementThoughts.Analyse(phrase)
                ?? _basicThoughts.Analyse(phrase)
                ?? _huefication.Analyse(phrase)
                ?? "Иди нахуй!";
        }
    }
}
