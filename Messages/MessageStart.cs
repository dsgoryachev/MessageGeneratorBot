using Telegram.Bot.Types.ReplyMarkups;
using UpsideBot.Constants;

namespace UpsideBot.Messages
{
    class MessageStart
    {
        internal string text = "";
        internal InlineKeyboardMarkup buttons = null;

        internal MessageStart()
        {
            text = "Выбери тип поста для публикации в канале:";

            var buttonsPostToChannel = new ButtonsGenerator();
            buttons = buttonsPostToChannel.ReturnStartButtons();
        }
    }
}
