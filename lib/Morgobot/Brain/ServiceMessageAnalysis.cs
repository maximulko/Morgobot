using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Morgobot.Brain
{
    public class ServiceMessageAnalysis
    {
        public string Analyse(Update update)
        {
            if (update.Message.Type ==  MessageType.ChatMembersAdded)
            {
                return "Это что за новый хуй?";
            }

            if (update.Message.Type == MessageType.ChatMemberLeft)
            {
                return "Сука, вернись!";
            }

            if (update.Message.Type == MessageType.Photo)
            {
                return "Классная фотка!";
            }

            if (update.Message.Type == MessageType.Sticker)
            {
                return "Классный стикер!";
            }

            if (update.Message.Type == MessageType.ChatPhotoDeleted)
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
