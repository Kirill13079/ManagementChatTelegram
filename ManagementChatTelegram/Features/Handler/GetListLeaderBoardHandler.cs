using ManagementChatTelegram.Data;
using ManagementChatTelegram.Features.Query;
using MediatR;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ManagementChatTelegram.Features.Handler
{
    public class GetListLeaderBoardHandler : IRequestHandler<GetListLeaderBoard, LeaderBoard[]>
    {
        public Task<LeaderBoard[]> Handle(GetListLeaderBoard request, CancellationToken cancellationToken)
        {
            var adress = @"https://playhearthstone.com/en-us/api/community/leaderboardsData?region=EU&leaderboardId=BG";
            WebClient client = new WebClient();
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(client.DownloadString(adress));
            List<LeaderBoard> leaderboardList = new List<LeaderBoard>();

            Season.Number = (int)obj["seasonId"] + 1;
            for (int i = 0; i < 8; i++)
            {
                LeaderBoard leaderboard = new LeaderBoard();
                leaderboard.AccountId = obj["leaderboard"]["rows"][i]["accountid"];
                leaderboard.Rank = obj["leaderboard"]["rows"][i]["rank"];
                leaderboard.Rating = obj["leaderboard"]["rows"][i]["rating"];
                leaderboardList.Add(leaderboard);
            }

            return Task.FromResult(leaderboardList.ToArray());
        }
    }
}
