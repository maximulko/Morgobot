using Dagon.Grammar;
using Morgobot.Infrastructure;

namespace Morgobot.Brain.ContextAnalysers
{
    public class SecretSantaAnalyzer : IContextAnalyzer
    {
        private readonly IPerChatCache _perChatCache;
        private const string StageCacheKey = "StageCacheKey";

        public SecretSantaAnalyzer(IPerChatCache perChatCache)
        {
            _perChatCache = perChatCache ?? throw new System.ArgumentNullException(nameof(perChatCache));
        }

        public int Order => 4;

        public string ContextName => "SecretSanta";

        public string[] ContextSwitchWords => new string[] { "секретный", "санта" };

        public BrainResponse Analyse(Phrase phrase, long chatId)
        {
            var stage = _perChatCache.Get<int?>(StageCacheKey, chatId);

            switch (stage)
            {
                case null:
                case 0:
                    _perChatCache.Set<int?>(StageCacheKey, chatId, 1);
                    return new BrainResponse("Скажи кто ты");
                case 1:
                    _perChatCache.Set<int?>(StageCacheKey, chatId, 2);
                    return new BrainResponse("Скажи кого ты любишь");
                case 2:
                    _perChatCache.Set<int?>(StageCacheKey, chatId, 3);
                    return new BrainResponse("Скажи свой вишлист");
                case 3:
                    return new BrainResponse("Спасибо!", true);
                default:
                    return null;
            }
            
        }
    }
}
