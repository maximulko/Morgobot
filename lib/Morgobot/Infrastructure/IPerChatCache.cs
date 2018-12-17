namespace Morgobot.Infrastructure
{
    public interface IPerChatCache
    {
        T Get<T>(string key, long chatId);
        void Set<T>(string key, long chatId, T data);
    }
}