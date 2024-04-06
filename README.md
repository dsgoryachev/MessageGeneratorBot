## Function of the telegram bot
Automate the process of posting trade messages to the group or channel.

User simply selects message type and submits input information. Bot generates message that can be posted to the group or channel directly from the bot.

## How does this bot work?
1. Bot offers 4 types of messages:

    ![image](https://github.com/dsgoryachev/MessageGeneratorBot/assets/109218841/81d5a453-731b-4eab-a9d4-0a597e4c7c86)
2. Select one of them by pressing the button
   
    ![image](https://github.com/dsgoryachev/MessageGeneratorBot/assets/109218841/9ae396fa-b2f5-42bb-9dcc-89f478bbccd2)
3. Send essential information to the bot

    ![image](https://github.com/dsgoryachev/MessageGeneratorBot/assets/109218841/103ec699-9edb-40fe-a8b8-bd779664a116)
4. Bot generates message, which can be posted to the channel or group

    ![image](https://github.com/dsgoryachev/MessageGeneratorBot/assets/109218841/d3e7e11b-0808-428a-8519-620582f74aff)


## Packages
* [.NET 5.0](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
* [Telegram.Bot 18.0.0](https://www.nuget.org/packages/Telegram.Bot/18.0.0?_src=template)

## Installation
Download repository and add your information in "Config" class 
![image](https://github.com/dsgoryachev/MessageGeneratorBot/assets/109218841/52482b5e-7044-4d53-9f31-b35253ebc1aa)
        
        internal const string TELEGRAM_BOT_API_TOKEN = "TOKEN";
        internal const string TELEGRAM_LOGS_GROUP = "@GROUP_NAME";
        internal const string PATH_TO_MAIN_FOLDER = @"PATH_TO_FOLDER_ON_YOUR_COMPUTER";
where:

`TOKEN` - token of your bot from [BotFather](https://t.me/BotFather) , as example `1873555505:AAH_3Hnf6666669Z_1pu47444444q9Ti64w`

`@GROUP_NAME` - 

`PATH_TO_FOLDER_ON_YOUR_COMPUTER` -
