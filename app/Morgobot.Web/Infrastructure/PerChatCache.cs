using Microsoft.Extensions.Caching.Memory;

namespace Morgobot.Web.Infrastructure
{
    public class PerChatCache
    {
        private readonly IMemoryCache _memoryCache;

        public PerChatCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache ?? throw new System.ArgumentNullException(nameof(memoryCache));
        }

        public void Set<T>(string key, long chatId, T data) where T : class
        {
            _memoryCache.Set(CreateKey(key, chatId), data);
        }

        public T Get<T>(string key, long chatId) where T: class
        {
            return _memoryCache.Get(CreateKey(key, chatId)) as T;
        }

        private static string CreateKey(string key, long chatId)
        {
            return $"{key}-{chatId}";
        }
    }
}
