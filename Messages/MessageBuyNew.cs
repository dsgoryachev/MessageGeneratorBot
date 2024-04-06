using System.IO;
using Telegram.Bot.Types.ReplyMarkups;
using MessageGeneratorBot.Main;

namespace MessageGeneratorBot.Messages
{
    class MessageBuyNew
    {
        internal string text = "";
        internal InlineKeyboardMarkup buttons = null;
        internal MessageBuyNew(bool isItARequest, string inputMessage)
        {
            if (isItARequest)
            {
                text =
                    $"<b>{ButtonsNames.BUY_NEW}</b>" + "\n" + "\n" +
                    "Отправь мне сообщение в таком формате:" + "\n" +
                    "<code>Тикер\nЦена Покупка\nЦена Стоп\nЦена Цель</code>" + "\n" + "\n" +
                    "<i>Пример сообщения:</i>" + "\n" +
                    "<code>SMLT\n52\n32\n80</code>";

                var buttonsBack = new ButtonsGenerator();
                buttons = buttonsBack.ReturnBackButton();
            }
            else
            {
                File.WriteAllText(Config.PATH_TO_CASH_FILE, inputMessage);

                string
                    ticker,
                    priceBuy,
                    priceStop,
                    pricePurpose;

                string[] variablesForPosting = File.ReadAllLines(Config.PATH_TO_CASH_FILE);

                text +=
                    "<b>Покупка </b>💎🚀" + "\n" +
                    "Тикер" + " " +
                    "<i>(кликните, чтобы скопировать):</i>" + "\n";

                switch (variablesForPosting.Length)
                {
                    case 4:
                        ticker = variablesForPosting[0].ToUpper();
                        priceBuy = variablesForPosting[1];
                        priceStop = variablesForPosting[2];
                        pricePurpose = variablesForPosting[3];

                        text +=
                            $"   <code>{ticker}</code>" + "\n" +
                            "Цена: " + priceBuy + "\n" +
                            "Стоп: " + priceStop + "\n" +
                            "Цель: " + pricePurpose + "\n";
                        break;

                    case 3:
                        ticker = variablesForPosting[0].ToUpper();
                        priceBuy = variablesForPosting[1];
                        priceStop = variablesForPosting[2];
                        text +=
                            $"   <code>{ticker}</code>" + "\n" +
                            "Цена: " + priceBuy + "\n" +
                            "Стоп: " + priceStop + "\n";
                        break;

                    case 2:
                        ticker = variablesForPosting[0].ToUpper();
                        priceBuy = variablesForPosting[1];
                        text +=
                            $"   <code>{ticker}</code>" + "\n" +
                            "Цена: " + priceBuy + "\n";
                        break;

                    case 1:
                        ticker = variablesForPosting[0].ToUpper();
                        text +=
                            $"   <code>{ticker}</code>" + "\n";
                        break;

                    default:
                        ticker = "???";
                        text += "Что-то пошло не так" + "\n";
                        break;
                }

                text +=
                    "Тип заявки: Лимитная" + "\n" +
                    "#" + ticker;

                var buttonsPostToChannel = new ButtonsGenerator();
                buttons = buttonsPostToChannel.ReturnPostToChannelButtons();
            }
        }
    }
}
