using System.IO;
using Telegram.Bot.Types.ReplyMarkups;
using UpsideBot.Constants;

namespace UpsideBot.Messages
{
    class MessageSellAll
    {
        internal string text = string.Empty;
        internal InlineKeyboardMarkup buttons = null;
        internal MessageSellAll(bool isItARequest, string inputMessage)
        {
            if (isItARequest)
            {
                text =
                    $"<b>{ButtonsNames.SELL_ALL}</b>" + "\n" + "\n" +
                    "Отправь мне: \n<code>Тикер</code>\n<code>Цена закрытия</code>\n\n" +
                    "<i>или</i>" + "\n" +
                    "<code>Тикер</code>";

                var buttonsBack = new ButtonsGenerator();
                buttons = buttonsBack.ReturnBackButton();
            }

            else
            {
                File.WriteAllText(Config.PATH_TO_CASH_FILE, inputMessage);

                string 
                    ticker,
                    price;

                string[] variablesForPosting = File.ReadAllLines(Config.PATH_TO_CASH_FILE);

                text +=
                    $"<b>{ButtonsNames.SELL_ALL}</b>" + "\n" +
                    "Тикер" + " " + "<i>(кликните, чтобы скопировать):</i>" + "\n";

                switch (variablesForPosting.Length)
                {
                    case 2:
                        ticker = variablesForPosting[0].ToUpper();
                        price = variablesForPosting[1];
                        text +=
                            $"   <code>{ticker}</code>" + "\n" +
                            "Цена продажи: " + price + "\n";
                        break;

                    case 1:
                        ticker = variablesForPosting[0].ToUpper();
                        text +=
                            $"   <code>{ticker}</code>" + "\n" +
                            "Цена продажи: По рынку" + "\n";
                        break;

                    default:
                        ticker = "???";
                        text += "Что-то пошло не так" + "\n";
                        break;
                }

                text +=
                    "#" + ticker;

                var buttonsPostToChannel = new ButtonsGenerator();
                buttons = buttonsPostToChannel.ReturnPostToChannelButtons();
            }
        }
    }
}
