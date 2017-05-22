using System.Linq;

namespace Morgobot.Brain
{
    public class MovementThoughts : IThought
    {
        private string[] Commands = { "вперед", "направо", "назад", "налево" };

        public string Analyse(string message)
        {
            if (!Commands.Any(c => message.StartsWith(c)))
            {
                return null;
            }

            return "Ок";
        }
    }
}
