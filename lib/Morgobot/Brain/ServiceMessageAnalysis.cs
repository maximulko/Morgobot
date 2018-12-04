using Telegram.Bot.Types.Enums;

namespace Morgobot.Brain
{
    public class ServiceMessageAnalysis
    {
        public string Analyse(string message, MessageType type)
        {
            if (type ==  MessageType.ChatMembersAdded)
            {
                return "Это что за новый хуй?";
            }

            if (type == MessageType.ChatMemberLeft)
            {
                return "Сука, вернись!";
            }

            if (type == MessageType.Photo)
            {
                return "Классная фотка!";
            }

            if (type == MessageType.Sticker)
            {
                return "Классный стикер!";
            }

            if (type == MessageType.ChatPhotoDeleted)
            {
                return "Куда дели фотку!!!!";
            }

            if (type == MessageType.ChannelCreated || type == MessageType.GroupCreated || type == MessageType.SupergroupCreated)
            {
                return "О, новый чатик! Опять от кого-то шифруемся?)))";
            }

            return "Телеграм от меня что-то хочет, а я не пойму что(((";
        }
    }
}
