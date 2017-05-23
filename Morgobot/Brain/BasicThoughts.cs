namespace Morgobot.Brain
{
    public class BasicThoughts : IThought
    {
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

            return "Иди нахуй!";
        }
    }
}
