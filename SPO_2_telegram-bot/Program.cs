using Microsoft.Extensions.Options;
using PRTelegramBot.Core;
using System.Data.Entity;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using SPO_2_telegram_bot.Data;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using System.Linq;

const string EXIT_COMMAND = "exit";




var telegram = new PRBot(option =>
{
    option.Token = "7141335057:AAEIMBOjb1i30CofVKq90qr8s9cjdaz3pys";
    option.ClearUpdatesOnStart = true;
    option.WhiteListUsers = new List<long>() { };
    option.Admins = new List<long>();
    option.BotId = 0;
    
});




telegram.OnLogCommon += Telegram_OnLogCommon;
telegram.OnLogError += Telegram_OnLogError;

await telegram.Start();

void Telegram_OnLogError(Exception ex, long? id)
{
    Console.ForegroundColor = ConsoleColor.Red;
    string errorMsg = $"{DateTime.Now};{ex}";
    Console.WriteLine(errorMsg);
    Console.ResetColor();
}

void Telegram_OnLogCommon(string msg, Enum typeEvent, ConsoleColor color)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    string message = $"{DateTime.Now};{msg}";
    Console.WriteLine(message);
    Console.ResetColor();
}
while (true)
{
    var result = Console.ReadLine();
    if (result.ToLower() == EXIT_COMMAND)
    {
        Environment.Exit(0);
    }
}







