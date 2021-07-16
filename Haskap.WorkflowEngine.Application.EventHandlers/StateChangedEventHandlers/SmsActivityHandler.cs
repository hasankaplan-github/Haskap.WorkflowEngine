using Haskap.WorkflowEngine.Domain.Core.RequestAggregate.DomainEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Application.EventHandlers.StateChangedEventHandlers
{
    public class SmsActivityHandler : INotificationHandler<StateChangedEvent>
    {
        public async Task Handle(StateChangedEvent notification, CancellationToken cancellationToken)
        {
            // user UseCaseServices to get activities belong to event data (pathId) and send sms.
            throw new NotImplementedException();
        }
    }
}
