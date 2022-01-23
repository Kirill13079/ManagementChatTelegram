using ManagementChatTelegram.Interfaces;
using MediatR;
using System.Drawing;

namespace ManagementChatTelegram.Features.Command
{
    public class SendImagePublication : IRequest<IEvent>
    {
        public Bitmap Image { get; set; }

        public SendImagePublication(Bitmap image)
        {
            Image = image;
        }
    }
}
