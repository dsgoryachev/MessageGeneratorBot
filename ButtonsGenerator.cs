using MessageGeneratorBot.Main;
using Telegram.Bot.Types.ReplyMarkups;

namespace MessageGeneratorBot
{
    class ButtonsGenerator
    {
        internal InlineKeyboardMarkup ReturnStartButtons()
        {
            // FULL AMOUNT OF BUTTONS
            InlineKeyboardButton[] btn_main_row1 = new InlineKeyboardButton[] { ButtonsNames.BUY_NEW, ButtonsNames.SELL_ALL };
            InlineKeyboardButton[] btn_main_row2 = new InlineKeyboardButton[] { ButtonsNames.BUY_PART, ButtonsNames.SELL_PART };

            // SHORT AMOUNT OF BUTTONS
            //InlineKeyboardButton[] btn_main_row1 = new InlineKeyboardButton[] { ButtonsNames.BUY_NEW, ButtonsNames.SELL_ALL };
            //InlineKeyboardButton[] btn_main_row2 = new InlineKeyboardButton[] { ButtonsNames.BUY_PART };
            InlineKeyboardButton[][] btn_main_all = new InlineKeyboardButton[][] { btn_main_row1, btn_main_row2 };

            return new InlineKeyboardMarkup(btn_main_all);
        }
        internal InlineKeyboardMarkup ReturnBackButton()
        {
            InlineKeyboardButton[] btn_main_row1 = new InlineKeyboardButton[] { ButtonsNames.BACK };
            InlineKeyboardButton[][] btn_main_all = new InlineKeyboardButton[][] { btn_main_row1 };
            return new InlineKeyboardMarkup(btn_main_all);
        }

        internal InlineKeyboardMarkup ReturnPostToChannelButtons()
        {
            InlineKeyboardButton[] btn_main_row1 = new InlineKeyboardButton[] { ButtonsNames.POST_TO_CHANNEL };
            InlineKeyboardButton[] btn_main_row2 = new InlineKeyboardButton[] { ButtonsNames.BACK };
            InlineKeyboardButton[][] btn_main_all = new InlineKeyboardButton[][] { btn_main_row1, btn_main_row2 };
            return new InlineKeyboardMarkup(btn_main_all);
        }
    }
}
