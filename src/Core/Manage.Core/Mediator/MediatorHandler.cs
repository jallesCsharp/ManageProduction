using Manage.Core.Mediator.Interfaces;
using Manage.Core.Messages;
using Manage.Core.Validation;
using MediatR;

namespace Manage.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishEvent<T>(T evnt) where T : Event
        {
            await _mediator.Publish(evnt);
        }

        public async Task<ValidationResultBag> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }
    }
}
