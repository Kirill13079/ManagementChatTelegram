using ManagementChatTelegram.Interfaces;
using MediatR;

namespace ManagementChatTelegram.Features.Command
{
    public class SendTextPublication : IRequest<IEvent>
    {
        public string Message { get; set; }

        public SendTextPublication(string text)
        {
            Message = text;
        }
    }
}
