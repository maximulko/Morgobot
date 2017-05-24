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

            if (message.Contains("300") || message.Contains("триста") || message.Contains("три сотни"))
            {
                return "Отсоси у тракториста!!! У ха ха ха ха!!!!";
            }

            if ((message.Contains("верни") || message.Contains("вернем") || message.Contains("отдай"))
                && (message.Contains("коня") || message.Contains("лошадь")))
            {
                return "Не брал я твоего коня!!!";
            }

            if (message.Contains("телефон"))
            {
                return "Я разбил свой телефон((( Хнык((";
            }

            if ((message.Contains("пиво") || message.Contains("бухать") || message.Contains("водку"))
                && !message.Contains("не"))
            {
                if (message.Contains("пойдем"))
                {
                    return "Пойдем!";
                }
                if (message.Contains("пошли"))
                {
                    return "Пошли!";
                }
                if (message.Contains("давай"))
                {
                    return "Давай!";
                }
            }

            return null;
        }
    }
}
