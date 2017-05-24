using System.Linq;

namespace Morgobot.Brain.Grammar
{
    public class Word
    {
        private readonly char[] _vowels = new[] {'а', 'у', 'о', 'ы', 'и', 'э', 'я', 'ю', 'ё', 'е'};

        private readonly string _word;

        public Word(string word)
        {
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