
namespace MessageGeneratorBot.Main
{
    class Config
    {
        internal const string TELEGRAM_BOT_API_TOKEN = "TOKEN";

        internal const string TELEGRAM_LOGS_GROUP = "@GROUP_NAME";

        internal const string PATH_TO_MAIN_FOLDER = @"C:\Users\d_goryachev\Desktop\1\_Visual Studio\Bot\";
        internal const string PATH_TO_FOLDER_USERS_INFO = PATH_TO_MAIN_FOLDER + @"UsersInfo\";
        internal const string PATH_TO_CASH_FILE = PATH_TO_MAIN_FOLDER + "Cash.txt";

        internal const string ERROR_FEEDBACK = "\nPlease, push command /start or if something is still wrong write to @dsgor";
        internal const string ERROR_THERE_IS_NO_USER_IN_DATABASE = "There is no such user in database." + ERROR_FEEDBACK;
        internal const string ERROR_THERE_IS_NO_ACCESS_TO_DATABASE_FOLDER = "There is no connection to database folder." + ERROR_FEEDBACK;
        internal const string ERROR_THERE_IS_NO_REACTION_FOR_THIS_BUTTON_YET = "There is no reaction for this button. " + ERROR_FEEDBACK;
        internal const string ERROR_YOU_DO_NOT_HAVE_PERMISSION_TO_USE_THIS_BOT = "You do not have permision to use this bot.";
    }
}
