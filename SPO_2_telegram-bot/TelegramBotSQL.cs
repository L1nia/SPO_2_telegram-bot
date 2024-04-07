using SPO_2_telegram_bot.Data;
using Microsoft.Extensions.Options;
using PRTelegramBot.Core;
using System.Data.Entity;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using SPO_2_telegram_bot.Data;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using System.Linq;
using PRTelegramBot.Models;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Server;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System;

// метод не рабочий =_=
namespace CETmsgr.dbutils
{
    internal class DataBaseMethods
    {
        public static async Task AddOrUpdateUser(int Chatid, string username, int bonus_count)
        {
            using (userstelegramContext db = new userstelegramContext())
            {
                var user = await db.Chats.FirstOrDefaultAsync(x => x.Chatid == Chatid);
                if (user is null)
                {
                    if (username == null)
                    {
                        username = "Без ника";
                    }
                    Chats newuser = new Chats { Chatid, username, bonus_count };
                    await db.Chats.AddAsync(newuser);
                    await db.SaveChangesAsync();
                }
                else
                {
                    user.Chatid = Chatid;
                    user.Username = username;
                    user.BonusCount = bonus_count;
                    db.Chats.Update(user);
                    await db.SaveChangesAsync();
                }
            }

        }







    }
}




