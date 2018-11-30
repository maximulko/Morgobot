using Dagon.Grammar;

namespace Morgobot.Brain
{
    public interface IAnalyzer
    {
        string Analyse(Phrase phrase);
        int Order { get; }
    }
}
