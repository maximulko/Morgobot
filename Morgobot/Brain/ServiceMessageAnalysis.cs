using Telegram.Bot.Types;

namespace Morgobot.Brain
{
    public class ServiceMessageAnalysis
    {
        public string Analyse(Update update)
        {
            if (update.Message.NewChatMember != null)
            {
                if (update.Message.NewChatMember.Id == 332048837)
                {
                    return "Вечер в хату, часик в радость!";
                }
                else
                {
                    return $"Добро пожаловать, {update.Message.NewChatMember.FirstName}! Веди себя хорошо и не матюкайся!";
                }
            }

            if (update.Message.LeftChatMember != null)
            {
                return $"Прощай, {update.Message.LeftChatMember.FirstName}. Я буду грустить(((";
            }

            if (update.Message.NewChatPhoto != null)
            {
                return "Классная фотка!";
            }

            if (update.Message.DeleteChatPhoto)
            {
                return "Куда дели фотку!!!!";
            }

            if (update.Message.ChannelChatCreated || update.Message.GroupChatCreated ||
                update.Message.SupergroupChatCreated)
            {
                return "О, новый чатик! Опять от кого-то шифруемся?)))";
            }

            return "Телеграм от меня что-то хочет, а я не пойму что(((";
        }
    }
}
