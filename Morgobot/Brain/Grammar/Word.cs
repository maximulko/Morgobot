using System.Linq;

namespace Morgobot.Brain.Grammar
{
    public class Word
    {
        private readonly char[] _vowels = {'а', 'у', 'о', 'ы', 'и', 'э', 'я', 'ю', 'ё', 'е'};
        private readonly char[] _consonants = { 'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ' };
        private readonly char[] _signs = {'ь', 'ъ'};
        private readonly char[] _numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        private readonly string _word;

        public Word(string word)
        {
            /*foreach (var letter in word.ToLower())
            {
                if (!_vowels.Contains(letter) && !_consonants.Contains(letter) && !_signs.Contains(letter) && !_numbers.Contains(letter))
                {
                    throw new GrammarException("Word can contain only vowels, consonants and signs.");
                }
            }*/

            _word = word;
        }

        public override string ToString()
        {
            return _word;
        }

        public int FindFirstVowelIndex()
        {
            for (var index = 0; index < _word.Length; index++)
            {
                if (IsVowel(index))
                {
                    return index;
                }
            }

            return -1;
        }

        public bool IsVowel(int index)
        {
            return _vowels.Contains(_word[index]);
        }

        public int Length => _word.Length;

        public char this[int index] => _word[index];

        public string Substring(int start, int len)
        {
            return _word.Substring(start, len);
        }
    }
}