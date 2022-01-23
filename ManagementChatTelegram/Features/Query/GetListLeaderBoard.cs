using ManagementChatTelegram.Data;
using MediatR;

namespace ManagementChatTelegram.Features.Query
{
    public class GetListLeaderBoard : IRequest<LeaderBoard[]>
    {

    }
}
