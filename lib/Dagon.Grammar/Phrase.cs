using System.Linq;

namespace Dagon.Grammar
{
    public class Phrase
    {
        private readonly char[] _punctuationMarks = { ',', '.', '!', '?', ';', '/', ':' };

        // TODO change type to Word[]
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

        public bool HasEnglisLetters()
        {
            return _words.Any(word => new Word(word).HasEnglisLetters());
        }

        public bool IsFirstWordEquals(string word)
        {
            return _words.Any() && _words.First() == word;
        }

        public Phrase RemoveFirstWord()
        {
            if (!_words.Any())
            {
                return this;
            }

            if (_words.Count() == 1)
            {
                return new Phrase(string.Empty);
            }

            return new Phrase(string.Join(" ", _words.Skip(1)));
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
