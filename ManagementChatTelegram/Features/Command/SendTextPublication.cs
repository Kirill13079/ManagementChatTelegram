using ManagementChatTelegram.Interfaces;
using MediatR;

namespace ManagementChatTelegram.Features.Command
{
    public class SendTextPublication : IRequest<IEvent>
    {
        public string Text { get; set; }

        public SendTextPublication(string text)
        {
            Text = text;
        }
    }
}
