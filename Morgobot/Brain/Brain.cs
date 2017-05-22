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
            message = message.ToLower();

            return _movementThoughts.Analyse(message) 
                ?? _basicThoughts.Analyse(message);
        }
    }
}
