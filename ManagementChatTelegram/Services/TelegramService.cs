using System.Net;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ManagementChatTelegram.Services
{
    public class TelegramService
    {
        private readonly TelegramBotClient _bot;
        private readonly ChatId _chat;

        public TelegramService(string token, long chat)
        {
            _bot = new TelegramBotClient(token);
            _chat = new ChatId(chat);
        }

        public TelegramBotClient Bot => _bot;
        public ChatId Chat => _chat;
    }
}
