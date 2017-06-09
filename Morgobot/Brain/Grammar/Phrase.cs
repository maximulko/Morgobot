using System.Linq;

namespace Morgobot.Brain.Grammar
{
    public class Phrase
    {
        private readonly char[] _punctuationMarks = { ',', '.', '!', '?', ';', '/', ':' };

        private readonly string[] _words;

        private readonly string _originalMessage;

        public Phrase(string message)
        {
            _originalMessage = message;
            _words = SplitByWords(message);
        }

        public bool HasWord(string word)
        {
            return HasAnyWord(word);
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
        public Word FirstWord => new Word(_words.First());

        private string[] SplitByWords(string message)
        {
            foreach (var punctuationMark in _punctuationMarks)
            {
                message = message.Replace(punctuationMark, ' ');
            }

            return message.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
        }

        public override string ToString()
        {
            return _originalMessage;
        }

        public bool IsEmpty()
        {
            return _words.Length == 0;
        }
    }
}
