﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpsideBot.Constants
{
    class Config
    {
        internal const string telegramBotAPIToken = "1873068905:AAH_3Hnf7pocYf9Z_1pu470mz488q9Ti64w";

        internal const string PATH_TO_MAIN_FOLDER = @"C:\Users\d_goryachev\Desktop\1\_Visual Studio\UpsideBot\";
        internal const string PATH_TO_FOLDER_USERS_INFO = PATH_TO_MAIN_FOLDER + @"UsersInfo\";
        internal const string PATH_TO_CASH_FILE = PATH_TO_MAIN_FOLDER + "Cash.txt";
        internal const string PATH_TO_LIST_OF_ADMINS_FILE = PATH_TO_MAIN_FOLDER + "ListOfAdmins.txt";

        internal const string ERROR_FEEDBACK = "\nPlease, push command /start or if something is still wrong write to @dsgor";
        internal const string ERROR_THERE_IS_NO_USER_IN_DATABASE = "There is no such user in database." + ERROR_FEEDBACK;
        internal const string ERROR_THERE_IS_NO_ACCESS_TO_DATABASE_FOLDER = "There is no connection to database folder." + ERROR_FEEDBACK;
        internal const string ERROR_THERE_IS_NO_REACTION_FOR_THIS_BUTTON_YET = "There is no reaction for this button. " + ERROR_FEEDBACK;
        internal const string ERROR_YOU_DO_NOT_HAVE_PERMISSION_TO_USE_THIS_BOT = "You do not have permision to use this bot.";
    }
}