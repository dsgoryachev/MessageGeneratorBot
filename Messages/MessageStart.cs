using Telegram.Bot.Types.ReplyMarkups;
using MessageGeneratorBot.Main;

namespace MessageGeneratorBot.Messages
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
