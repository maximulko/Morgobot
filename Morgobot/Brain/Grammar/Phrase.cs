using System.Linq;

namespace Morgobot.Brain.Grammar
{
    public class Phrase
    {
        private readonly char[] _vowels = new[] { 'а', 'у', 'о', 'ы', 'и', 'э', 'я', 'ю', 'ё', 'е' };
        private readonly char[] _punctuationMarks = new[] { ',', '.', '!', '?', ';' };

        private readonly string[] _words;

        public Phrase(string message)
        {
            _words = SplitByWords(message);
        }

        public bool HasWord(string word)
        {
            return _words.Any(w => w == word);
        }

        public bool HasAnyWord(params string[] words)
        {
            foreach (var word in words)
            {
                if (_words.Any(w => w == word))
                {
                    return true;
                }
            }

            return false;
        }

        public Word LastWord => new Word(_words.Last());

        private string[] SplitByWords(string message)
        {
            foreach (var punctuationMark in _punctuationMarks)
            {
                message = message.Replace(punctuationMark, ' ');
            }

            return message.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
        }
    }
}
