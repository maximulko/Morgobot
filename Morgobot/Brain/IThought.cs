using Morgobot.Brain.Grammar;

namespace Morgobot.Brain
{
    public interface IAnalyzer
    {
        string Analyse(Phrase phrase);
        int Order { get; }
    }
}
