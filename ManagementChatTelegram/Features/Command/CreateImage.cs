using ManagementChatTelegram.Data;
using MediatR;
using System.Collections.Generic;
using System.Drawing;

namespace ManagementChatTelegram.Features.Command
{
    public class CreateImage : IRequest<Bitmap>
    {
        public List<LeaderBoard> Leaders { get; set; }

        public CreateImage(List<LeaderBoard> leaders)
        {
            Leaders = leaders;
        }
    }
}
