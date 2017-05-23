using Morgobot.Brain.Movements;

namespace Morgobot.Brain
{
    public class Brain
    {
        private BasicThoughts _basicThoughts;
        private MovementThoughts _movementThoughts;

        public Brain(BasicThoughts basicThoughts, MovementThoughts movementThoughts)
        {
            _basicThoughts = basicThoughts;
            _movementThoughts = movementThoughts;
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
                ?? _basicThoughts.Analyse(message);
        }
    }
}
