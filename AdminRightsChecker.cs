using MessageGeneratorBot.Constants;
using System.IO;

namespace MessageGeneratorBot
{
    class AdminRightsChecker
    {
        internal bool isUserAnAdmin = false;
        internal AdminRightsChecker(string userID)
        {
            if (File.Exists(Config.PATH_TO_LIST_OF_ADMINS_FILE))
            {
                string[] listOfAdmins = File.ReadAllLines(Config.PATH_TO_LIST_OF_ADMINS_FILE);

                foreach (string user in listOfAdmins)
                {
                    if(user == userID)
                    {
                        isUserAnAdmin = true;
                    }
                }
            }
        }
    }
}
