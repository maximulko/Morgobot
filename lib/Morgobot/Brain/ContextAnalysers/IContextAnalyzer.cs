using Dagon.Grammar;

namespace Morgobot.Brain.ContextAnalysers
{
    public interface IContextAnalyzer
    {
        string[] ContextSwitchWords { get; }
        string ContextName { get; }
        BrainResponse Analyse(Phrase phrase, long chatId);
    }
}
