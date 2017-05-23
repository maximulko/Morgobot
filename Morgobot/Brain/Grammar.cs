using System.Linq;

namespace Morgobot.Brain
{
    public class Grammar
    {
        public int FindLastSpace(string message)
        {
            for (var index = message.Length - 1; index >= 0; index--)
            {
                if (message[index] == ' ')
                {
                    return index;
                }
            }

            return -1;
        }

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
    }
}
