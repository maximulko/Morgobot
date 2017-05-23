using System.Collections.Generic;

namespace Morgobot.Brain
{
    public class Huefication : IThought
    {
        private readonly Grammar _grammar;

        public Huefication(Grammar grammar)
        {
            _grammar = grammar;
        }

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

        public string Analyse(string message)
        {
            return HuefyPhrase(message);
        }

        private string HuefyWord(string word)
        {
            int firstVowelIndex = _grammar.FindFirstVowel(word);

            if (firstVowelIndex == -1)
            {
                return null;
            }

            var firstPart = "Ху" + _rules[word[firstVowelIndex]];
            var secondPart = word.Substring(firstVowelIndex + 1, word.Length - firstVowelIndex - 1);

            return firstPart + secondPart;
        }

        private string HuefyPhrase(string message)
        {
            var lastSpaceIndex = _grammar.FindLastSpace(message);

            if (lastSpaceIndex == -1)
            {
                return HuefyWord(message);
            }

            var lastWord = message.Substring(lastSpaceIndex + 1, message.Length - lastSpaceIndex - 1);
            
            return HuefyWord(lastWord);
        }
    }
}
