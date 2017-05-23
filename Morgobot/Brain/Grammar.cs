using System.Linq;

namespace Morgobot.Brain
{
    public class Grammar
    {
        private readonly char[] _vowels = new[] { 'а', 'у', 'о', 'ы', 'и', 'э', 'я', 'ю', 'ё', 'е' };

        public int FindFirstVowel(string message)
        {
            for (var index = 0; index < message.Length; index++)
            {
                if (IsVowel(message[index]))
                {
                    return index;
                }
            }

            return -1;
        }

        public bool IsVowel(char letter)
        {
            return _vowels.Contains(letter);
        }

        public string[] SplitByWords(string message)
        {
            return message.Split(' ');
        }
    }
}
