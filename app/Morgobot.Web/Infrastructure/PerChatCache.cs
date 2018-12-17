using Microsoft.Extensions.Caching.Memory;
using Morgobot.Infrastructure;

namespace Morgobot.Web.Infrastructure
{
    public class PerChatCache : IPerChatCache
    {
        private readonly IMemoryCache _memoryCache;

        public PerChatCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache ?? throw new System.ArgumentNullException(nameof(memoryCache));
        }

        public void Set<T>(string key, long chatId, T data)
        {
            _memoryCache.Set(CreateKey(key, chatId), data);
        }

        public T Get<T>(string key, long chatId)
        {
            return (T)_memoryCache.Get(CreateKey(key, chatId));
        }

        private static string CreateKey(string key, long chatId)
        {
            return $"{key}-{chatId}";
        }
    }
}
