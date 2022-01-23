using ManagementChatTelegram.Events;
using ManagementChatTelegram.Features.Command;
using ManagementChatTelegram.Interfaces;
using ManagementChatTelegram.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ManagementChatTelegram.Features.Handler
{
    public class SendTextPublicationHandel : IRequestHandler<SendTextPublication, IEvent>
    {
        private readonly TelegramService _telegram;

        public SendTextPublicationHandel(TelegramService telegram)
        {
            _telegram = telegram;
        }

        public Task<IEvent> Handle(SendTextPublication request, CancellationToken cancellationToken)
        {
            try
            {
                Message message = _telegram.Bot.SendTextMessageAsync(_telegram.Chat, request.Message).GetAwaiter().GetResult();
                return Task.FromResult((IEvent)new Succes("Message send"));
            }
            catch (Exception ex)
            {
                return Task.FromResult((IEvent)new Errors(ex.Message));
            }
        }
    }
}
