using System.IO;
using Telegram.Bot.Types.ReplyMarkups;
using UpsideBot.Messages;
using UpsideBot.Constants;

namespace UpsideBot
{
    class MessageBuilder
    {
        internal bool isItMessageToPostInChannel = false;
        internal string outputText = string.Empty;
        internal InlineKeyboardMarkup buttons = null;

        internal MessageBuilder(string inputMessage, string userID, bool isItButton)
        {
            if (isItButton)
            {
                switch (inputMessage)
                {
                    case ButtonsNames.BUY_NEW:
                        ReturnBuyNewMessageAsRequest();
                        break;

                    case ButtonsNames.SELL_ALL:
                        ReturnSellAllMessageAsRequest();
                        break;

                    case ButtonsNames.BUY_PART:
                        ReturnBuyPartMessageAsRequest();
                        break;

                    case ButtonsNames.SELL_PART:
                        ReturnSellPartMessageAsRequest();
                        break;

                    case ButtonsNames.BACK:
                        ReturnStartMessage();
                        break;

                    case ButtonsNames.POST_TO_CHANNEL:
                        outputText = ReadMessageTextFromFile(userID);
                        isItMessageToPostInChannel = true;
                        break;

                    default:
                        outputText = Config.ERROR_THERE_IS_NO_REACTION_FOR_THIS_BUTTON_YET;
                        break;
                }

                if (IsUserExist(userID))
                {
                    WriteStageOfUserToFile(userID, inputMessage);
                }
                else
                {
                    WriteStageOfUserToFile(userID, inputMessage);
                    ReadInfoAboutAtWhatStageUserNow(userID);
                }
            }

            else
            {
                switch (inputMessage)
                {
                    case "/start":
                        WriteStageOfUserToFile(userID, inputMessage);
                        ReturnStartMessage();
                        break;

                    default:
                        switch (ReadInfoAboutAtWhatStageUserNow(userID))
                        {
                            case ButtonsNames.BUY_NEW:
                                ReturnBuyNewMessage(inputMessage);
                                SaveMessageTextToFile(userID);
                                break;

                            case ButtonsNames.SELL_ALL:
                                ReturnSellAllMessage(inputMessage);
                                SaveMessageTextToFile(userID);
                                break;

                            case ButtonsNames.BUY_PART:
                                ReturnBuyPartMessage(inputMessage);
                                SaveMessageTextToFile(userID);
                                break;

                            case ButtonsNames.SELL_PART:
                                ReturnSellPartMessage(inputMessage);
                                SaveMessageTextToFile(userID);
                                break;

                            default:
                                outputText = ReadInfoAboutAtWhatStageUserNow(userID);
                                buttons = null;
                                break;
                        }
                        break;
                }
            }
        }
        internal bool IsUserExist(string id)
        {
            if (File.Exists(Config.PATH_TO_FOLDER_USERS_INFO + id + ".txt"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal string ReadInfoAboutAtWhatStageUserNow(string id)
        {
            try
            {
                return File.ReadAllText(Config.PATH_TO_FOLDER_USERS_INFO + id + ".txt");
            }
            catch 
            {
                return Config.ERROR_THERE_IS_NO_USER_IN_DATABASE;
            }
        }
        internal string WriteStageOfUserToFile(string id, string stage)
        {
            try
            {
                File.WriteAllText(Config.PATH_TO_FOLDER_USERS_INFO + id + ".txt", stage);
                return "Successfully saved";
            }
            catch
            {
                return Config.ERROR_THERE_IS_NO_ACCESS_TO_DATABASE_FOLDER;
            }
        }
        internal void ReturnStartMessage ()
        {
            var msgStart = new MessageStart();
            outputText = msgStart.text;
            buttons = msgStart.buttons;
        }
        internal void ReturnBuyNewMessageAsRequest()
        {
            var msgBuyNew = new MessageBuyNew(true, null);
            outputText = msgBuyNew.text;
            buttons = msgBuyNew.buttons;
        }
        internal void ReturnBuyNewMessage(string inputMessage)
        {
            var msgBuyNew = new MessageBuyNew(false, inputMessage);
            outputText = msgBuyNew.text;
            buttons = msgBuyNew.buttons;
        }
        internal void ReturnSellAllMessageAsRequest()
        {
            var msg = new MessageSellAll(true, null);
            outputText = msg.text;
            buttons = msg.buttons;
        }
        internal void ReturnSellAllMessage(string inputMessage)
        {
            var msg = new MessageSellAll(false, inputMessage);
            outputText = msg.text;
            buttons = msg.buttons;
        }
        internal void ReturnBuyPartMessageAsRequest()
        {
            var msg = new MessageBuyPart(true, null);
            outputText = msg.text;
            buttons = msg.buttons;
        }
        internal void ReturnBuyPartMessage(string inputMessage)
        {
            var msg = new MessageBuyPart(false, inputMessage);
            outputText = msg.text;
            buttons = msg.buttons;
        }
        internal void ReturnSellPartMessageAsRequest()
        {
            var msg = new MessageSellPart(true, null);
            outputText = msg.text;
            buttons = msg.buttons;
        }
        internal void ReturnSellPartMessage(string inputMessage)
        {
            var msg = new MessageSellPart(false, inputMessage);
            outputText = msg.text;
            buttons = msg.buttons;
        }
        internal void SaveMessageTextToFile(string userID)
        {
            try
            {
                File.WriteAllText(Config.PATH_TO_FOLDER_USERS_INFO + userID + "_postToChannel" + ".txt", outputText);
            }
            catch
            {
                outputText = Config.ERROR_THERE_IS_NO_ACCESS_TO_DATABASE_FOLDER;
            }
        }
        internal static string ReadMessageTextFromFile(string userID)
        {
            try
            {
                return File.ReadAllText(Config.PATH_TO_FOLDER_USERS_INFO + userID + "_postToChannel" + ".txt");
            }
            catch
            {
                return Config.ERROR_THERE_IS_NO_ACCESS_TO_DATABASE_FOLDER;
            }
        }
    }
}
