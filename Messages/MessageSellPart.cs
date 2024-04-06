using System.IO;
using Telegram.Bot.Types.ReplyMarkups;
using MessageGeneratorBot.Main;

namespace MessageGeneratorBot.Messages
{
    class MessageSellPart
    {
        internal string text = string.Empty;
        internal InlineKeyboardMarkup buttons = null;
        internal MessageSellPart(bool isItARequest, string inputMessage)
        {
            if (isItARequest)
            {
                text =
                    $"<b>{ButtonsNames.SELL_PART}</b>" + "\n" + "\n" +
                    "Пришли мне:" + "\n" +
                    "<code>Тикер\nОбъем продажи, %\nЦена</code>" + "\n" + "\n" +
                    "<i>или</i>" + "\n" +
                    "<code>Тикер\nОбъем продажи, %</code>" + "\n" + "\n" +
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
                    volumeInPercent,
                    price;

                string[] variablesForPosting = File.ReadAllLines(Config.PATH_TO_CASH_FILE);

                text +=
                    $"<b>{ButtonsNames.SELL_PART}</b>" + "\n" +
                    "Тикер" + " " +
                    "<i>(кликните, чтобы скопировать):</i>" + "\n";

                switch (variablesForPosting.Length)
                {
                    case 3:
                        ticker = variablesForPosting[0].ToUpper();
                        volumeInPercent = variablesForPosting[1];
                        price = variablesForPosting[2];
                        text +=
                            $"   <code>{ticker}</code>" + "\n" +
                            "Объем: " + volumeInPercent + "%" + "\n" +
                            "Цена: " + price + "\n";
                        break;

                    case 2:
                        ticker = variablesForPosting[0].ToUpper();
                        volumeInPercent = variablesForPosting[1];
                        text +=
                            $"   <code>{ticker}</code>" + "\n" +
                            "Объем: " + volumeInPercent + "%" + "\n" +
                            "Тип заявки: Рыночная" + "\n";
                        break;

                    case 1:
                        ticker = variablesForPosting[0].ToUpper();
                        text +=
                            $"   <code>{ticker}</code>" + "\n" +
                            "Тип заявки: Рыночная" + "\n";
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
