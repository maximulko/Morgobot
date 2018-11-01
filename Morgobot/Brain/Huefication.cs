using System.Collections.Generic;
using Morgobot.Brain.Grammar;

namespace Morgobot.Brain
{
    public class Huefication : IAnalyzer
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

        public string Analyse(Phrase phrase)
        {
            if (phrase.IsEmpty())
            {
                return null;
            }

            return HuefyPhrase(phrase);
        }

        private string HuefyWord(Word word)
        {
            int firstVowelIndex = word.FindFirstVowelIndex();

            if (firstVowelIndex == -1)
            {
                return null;
            }

            while (firstVowelIndex < word.Length - 1 && word.IsVowel(firstVowelIndex + 1))
            {
                firstVowelIndex++;
            }

            var firstPart = "Ху" + _rules[word[firstVowelIndex]];
            var secondPart = word.Substring(firstVowelIndex + 1, word.Length - firstVowelIndex - 1);

            return firstPart + secondPart;
        }

        private string HuefyPhrase(Phrase phrase)
        {
            var huefied = HuefyWord(phrase.LastWord);

            return huefied == null ? null : huefied + "!";
        }
    }
}
