using System;
using System.Linq;
using ManagementChatTelegram.Events;
using ManagementChatTelegram.Features.Command;
using ManagementChatTelegram.Features.Query;
using MediatR;

namespace ManagementChatTelegram
{
    public class Management
    {
        private readonly IMediator _mediator;

        public Management(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async void Start()
        {
            var leaders = await _mediator.Send(new GetListLeaderBoard());
            var image = await _mediator.Send(new CreateImage(leaders.ToList()));
            await _mediator.Send(new SendImagePublication(image));
        }
    }
}
