using Morgobot.Brain.Grammar;

namespace Morgobot.Brain
{
    interface IAnalyzer
    {
        string Analyse(Phrase phrase);
    }
}
