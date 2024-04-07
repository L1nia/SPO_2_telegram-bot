using System;
using System.Collections.Generic;

namespace SPO_2_telegram_bot.Data
{
    public partial class Chat
    {
        public int Chatid { get; set; }
        public string Username { get; set; } = null!;
        public int? BonusCount { get; set; }
    }
}
