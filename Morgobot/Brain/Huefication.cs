using System.Collections.Generic;
using System.Linq;

namespace Morgobot.Brain
{
    public class Huefication
    {
        private readonly Dictionary<char, char> _rules = new Dictionary<char, char>
        {
            {'а', 'я'},
            {'у', 'ю'},
            {'о', 'ё'},
            {'ы', 'ы'},
            {'и', 'и'},
            {'э', 'э'},
            {'я', 'я'},
            {'ю', 'ю'},
            {'ё', 'ё'},
            {'е', 'е'},
        };

        public string Huefy(string message)
        {
            message = message.ToLower();

            int firstVowelIndex = FindFirstVowel(message);

            if (firstVowelIndex == -1)
            {
                return null;
            }

            var firstPart = "Ху" + _rules[message[firstVowelIndex]];
            var secondPart = message.Substring(firstVowelIndex + 1, message.Length - firstVowelIndex - 1);

            return firstPart + secondPart;
        }

        public string HuefyPhrase(string message)
        {
            var lastSpaceIndex = FindLastSpace(message);

            if (lastSpaceIndex == -1)
            {
                return Huefy(message);
            }

            var lastWord = message.Substring(lastSpaceIndex + 1, message.Length - lastSpaceIndex - 1);
            
            return Huefy(lastWord);
        }

        private int FindLastSpace(string message)
        {
            for (var index = message.Length-1; index >=0 ; index--)
            {
                if (message[index]==' ')
                {
                    return index;
                }
            }

            return -1;
        }

        private int FindFirstVowel(string message)
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
