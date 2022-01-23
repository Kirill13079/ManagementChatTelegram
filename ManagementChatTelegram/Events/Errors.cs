using ManagementChatTelegram.Interfaces;

namespace ManagementChatTelegram.Events
{
    public class Errors : IEvent
    {
        public string Message { get; set; }

        public Errors(string message)
        {
            Message = message;
        }
    }
}
