using Dagon.Grammar;
using Morgobot.Brain;
using Morgobot.Brain.ContextAnalysers;
using Morgobot.Web.Infrastructure;
using System.Collections.Generic;

namespace Morgobot.Web.Brain
{
    public class ContextSwitchAnalyzer : IAnalyzer
    {
        private readonly IEnumerable<IContextAnalyzer> _contextAnalyzers;
        private readonly PerChatCache _perChatCache;

        public int Order => -1;
        private const string CurrentContextCacheKey = "CurrentContext";

        public ContextSwitchAnalyzer(
            IEnumerable<IContextAnalyzer> contextAnalyzers,
            PerChatCache perChatCache)
        {
            _contextAnalyzers = contextAnalyzers ?? throw new System.ArgumentNullException(nameof(contextAnalyzers));
            _perChatCache = perChatCache ?? throw new System.ArgumentNullException(nameof(perChatCache));
        }

        public string Analyse(Phrase phrase, long chatId)
        {
            if(phrase.HasAllWords("скажи", "контекст"))
            {
                return _perChatCache.Get<string>(CurrentContextCacheKey, chatId);
            }

            foreach (var contextAnalyzer in _contextAnalyzers)
            {
                if (phrase.HasAllWords(contextAnalyzer.ContextSwitchWords))
                {
                    _perChatCache.Set(CurrentContextCacheKey, chatId, contextAnalyzer.ContextName);
                }
            }

            return null;
        }
    }
}
