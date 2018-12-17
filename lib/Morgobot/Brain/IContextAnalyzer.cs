using Dagon.Grammar;

namespace Morgobot.Brain
{
    interface IContextAnalyzer
    {
        string ContextName { get; }
        string Analyse(Phrase phrase);
    }
}
