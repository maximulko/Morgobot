using System;

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

            return "Иди нахуй!";
        }
    }
}
