using Dagon.Grammar;
using Morgobot.Brain;
using Morgobot.Brain.ContextAnalysers;
using Morgobot.Infrastructure;
using System.Collections.Generic;

namespace Morgobot.Web.Brain
{
    public class ContextSwitchAnalyzer : IAnalyzer
    {
        private readonly IEnumerable<IContextAnalyzer> _contextAnalyzers;
        private readonly IPerChatCache _perChatCache;

        public int Order => -1;
        private const string CurrentContextCacheKey = "CurrentContext";

        public ContextSwitchAnalyzer(
            IEnumerable<IContextAnalyzer> contextAnalyzers,
            IPerChatCache perChatCache)
        {
            _contextAnalyzers = contextAnalyzers ?? throw new System.ArgumentNullException(nameof(contextAnalyzers));
            _perChatCache = perChatCache ?? throw new System.ArgumentNullException(nameof(perChatCache));
        }

        public string Analyse(Phrase phrase, long chatId)
        {
            if(phrase.HasAllWords("скажи", "контекст"))
            {
                string contextName = _perChatCache.Get<string>(CurrentContextCacheKey, chatId);
                return contextName ?? "Нет контекста";
            }

            foreach (var contextAnalyzer in _contextAnalyzers)
            {
                if (phrase.HasAllWords(contextAnalyzer.ContextSwitchWords))
                {
                    _perChatCache.Set(CurrentContextCacheKey, chatId, contextAnalyzer.ContextName);
                    var response = contextAnalyzer.Analyse(phrase);

                    if (response.ClenUpCurrentContext)
                    {
                        _perChatCache.Set<string>(CurrentContextCacheKey, chatId, null);
                    }

                    return response.Text;
                }
            }

            return null;
        }
    }
}
