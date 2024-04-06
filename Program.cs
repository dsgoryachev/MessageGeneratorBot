using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using System.Threading.Tasks;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using MessageGeneratorBot.Main;

namespace MessageGeneratorBot
{
    class Program
    {
        static void Main(string[] args)
        {
            ITelegramBotClient bot = new TelegramBotClient(Config.TELEGRAM_BOT_API_TOKEN);
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                //All types are allowed
                AllowedUpdates = { }
            };
            bot.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOptions, cancellationToken);
            Console.ReadLine();
        }

        private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is Message message)
            {
                if (message.Text != null)
                {
                    var textMessage = new MessageBuilder(message.Text, Convert.ToString(message.From.Id), false);
                    await botClient.SendTextMessageAsync(message.Chat, textMessage.outputText, replyMarkup: textMessage.buttons, parseMode: ParseMode.Html);

                    // Logs to the telegram group
                    await botClient.ForwardMessageAsync(Config.TELEGRAM_LOGS_GROUP, message.Chat.Id, message.MessageId);
                }
            }
            else if (update.CallbackQuery is CallbackQuery callback)
            {
                var buttonMessage = new MessageBuilder(update.CallbackQuery.Data, Convert.ToString(update.CallbackQuery.From.Id), true);

                if (buttonMessage.isItMessageToPostInChannel)
                {
                    await botClient.SendTextMessageAsync(-1001678912928, buttonMessage.outputText, replyMarkup: buttonMessage.buttons, parseMode: ParseMode.Html);
                    await botClient.SendTextMessageAsync(callback.From.Id, ButtonsNames.POSTED_SUCCESSEFULLY, parseMode: ParseMode.Html);

                    var startMessage = new MessageBuilder("/start", Convert.ToString(update.CallbackQuery.From.Id), false);
                    await botClient.SendTextMessageAsync(callback.From.Id, startMessage.outputText, replyMarkup: startMessage.buttons, parseMode: ParseMode.Html);
                }
                else
                {
                    await botClient.SendTextMessageAsync(callback.From.Id, buttonMessage.outputText, replyMarkup: buttonMessage.buttons, parseMode: ParseMode.Html);
                }
            }
        }
        private static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is ApiRequestException apiRequestException)
            {
                await botClient.SendTextMessageAsync(Config.TELEGRAM_LOGS_GROUP, apiRequestException.ToString());
            }
        }
    }
}
