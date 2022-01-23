using ManagementChatTelegram.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ManagementChatTelegram.Features.Command;
using ManagementChatTelegram.Interfaces;
using System.Threading;
using Telegram.Bot.Types;
using ManagementChatTelegram.Data;
using System.IO;
using ManagementChatTelegram.Events;
using Telegram.Bot;

namespace ManagementChatTelegram.Features.Handler
{
    public class SendImagePublicationHandler : IRequestHandler<SendImagePublication, IEvent>
    {
        private readonly TelegramService _telegram;

        public SendImagePublicationHandler(TelegramService telegram)
        {
            _telegram = telegram;
        }

        public Task<IEvent> Handle(SendImagePublication request, CancellationToken cancellationToken)
        {
            try
            {
                using (Stream stream = System.IO.File.OpenRead("LeaderBord.png"))
                {
                    InputMediaPhoto[] inputMedia = { new InputMediaPhoto(new InputMedia(stream, "LeaderBord.png"))
                    {
                        Caption = $"Лидеры {Season.Number} сезона.",
                        ParseMode = Telegram.Bot.Types.Enums.ParseMode.Html
                    }};

                    _telegram.Bot.SendMediaGroupAsync(chatId: _telegram.Chat, media: inputMedia).GetAwaiter().GetResult();

                    return Task.FromResult((IEvent)new Succes("Message send"));
                }
            }
            catch(Exception ex) 
            {
                return Task.FromResult((IEvent)new Errors(ex.Message));
            }
        }
    }
}
