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

            return new BrainResponse
            {
                Text = "Привет из санты",
                ClenUpCurrentContext = true
            };
        }
    }
}
