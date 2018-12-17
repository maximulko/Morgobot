namespace Morgobot.Infrastructure
{
    public interface IPerChatCache
    {
        T Get<T>(string key, long chatId) where T : class;
        void Set<T>(string key, long chatId, T data) where T : class;
    }
}