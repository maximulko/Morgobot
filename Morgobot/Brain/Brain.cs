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

        public string Analyse(string message)
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

            return _movementThoughts.Analyse(message)
                ?? _huefication.Analyse(message)
                ?? _basicThoughts.Analyse(message);
        }
    }
}
