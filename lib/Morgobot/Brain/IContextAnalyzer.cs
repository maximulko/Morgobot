using Dagon.Grammar;

namespace Morgobot.Brain
{
    public interface IContextAnalyzer
    {
        string[] ContextSwitchWords { get; }
        string ContextName { get; }
        string Analyse(Phrase phrase);
    }
}
