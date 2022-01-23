using ManagementChatTelegram.Interfaces;

namespace ManagementChatTelegram.Events
{
    public class Succes : IEvent
    {
        public string Message { get; set; }

        public Succes(string message)
        {
            Message = message;
        }
    }
}
