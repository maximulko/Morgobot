using System.Linq;

namespace Morgobot.Brain
{
    public class Grammar
    {
        public int FindFirstVowel(string message)
        {
            var vowels = new[] { 'а', 'у', 'о', 'ы', 'и', 'э', 'я', 'ю', 'ё', 'е' };

            for (var index = 0; index < message.Length; index++)
            {
                if (vowels.Contains(message[index]))
                {
                    return index;
                }
            }

            return -1;
        }

        public string[] SplitByWords(string message)
        {
            return message.Split(' ');
        }
    }
}
