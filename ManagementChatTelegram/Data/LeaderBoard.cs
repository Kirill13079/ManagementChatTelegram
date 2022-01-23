using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ManagementChatTelegram.Data
{
    public static class Season
    {
        public static int Number { get; set; }
    }

    public class LeaderBoard
    {
        public string AccountId { get; set; }
        public string Rank { get; set; }
        public string Rating { get; set; }

        public override string ToString() => $"{Rank} {AccountId} {Rating}";
    }
}
