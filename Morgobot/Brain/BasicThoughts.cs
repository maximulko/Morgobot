namespace Morgobot.Brain
{
    public class BasicThoughts : IThought
    {
        private readonly Huefication _huefication;

        public BasicThoughts(Huefication huefication)
        {
            _huefication = huefication;
        }

        public string Analyse(string message)
        {
            if (message.Contains("гусь"))
            {
                return "Сам ты гусь";
            }

            if (message.Contains("пукнуть") || message.Contains("пукни"))
            {
                return "\u2601";
            }

            if (message.Contains("зигани"))
            {
                return "o/";
            }

            if (message.Contains("спасибо"))
            {
                return "Пожалуйста";
            }

            if (message.Contains("привет"))
            {
                return "Привет, козлик!";
            }

            var huefiedMessage = _huefication.HuefyPhrase(message);

            if (!string.IsNullOrWhiteSpace(huefiedMessage))
            {
                return huefiedMessage + "!";
            }

            return "Иди нахуй!";
        }
    }
}
