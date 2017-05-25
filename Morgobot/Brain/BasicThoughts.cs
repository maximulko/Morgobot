using Morgobot.Brain.Grammar;

namespace Morgobot.Brain
{
    public class BasicThoughts : IThought
    {
        public string Analyse(Phrase phrase)
        {
            if (phrase.ToString() == "start")
            {
                return "Вечер в хату, часик в радость!";
            }

            if (phrase.HasWord("гусь"))
            {
                return "Сам ты гусь";
            }

            if (phrase.HasAnyWord("пукнуть","пукни"))
            {
                return "\u2601";
            }

            if (phrase.HasWord("зигани"))
            {
                return "o/";
            }

            if (phrase.HasWord("спасибо"))
            {
                return "Пожалуйста";
            }

            if (phrase.HasWord("привет"))
            {
                return "Привет, козлик!";
            }

            if (phrase.HasAnyWord("300", "триста", "три сотни"))
            {
                return "Отсоси у тракториста!!! У ха ха ха ха!!!!";
            }

            if (phrase.HasAnyWord("верни", "вернем", "отдай") && phrase.HasAnyWord("коня", "лошадь"))
            {
                return "Не брал я твоего коня!!!";
            }

            if (phrase.HasWord("телефон"))
            {
                return "Я разбил свой телефон((( Хнык((";
            }

            if (phrase.HasAnyWord("пиво", "бухать", "водку") && !phrase.HasWord("не"))
            {
                if (phrase.HasWord("пойдем"))
                {
                    return "Пойдем!";
                }
                if (phrase.HasWord("пошли"))
                {
                    return "Пошли!";
                }
                if (phrase.HasWord("давай"))
                {
                    return "Давай!";
                }
            }

            if (phrase.LastWord.ToString() == "да")
            {
                return "Пизда!";
            }

            if (phrase.LastWord.ToString() == "нет")
            {
                return "Пидора ответ!";
            }

            return null;
        }
    }
}
