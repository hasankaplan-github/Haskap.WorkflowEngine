using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Core.RequestAggregate.DomainEvents
{
    [Serializable]
    public class StateChangedEvent : INotification
    {
        public Guid RequestId { get; }
        public Guid PathId { get; }
        public Dictionary<string, object> NotificationData { get; }

        public StateChangedEvent(Guid requestId, Guid pathId, Dictionary<string, object> notificationData)
        {
            RequestId = requestId;
            PathId = pathId;
            NotificationData = notificationData;
        }
    }
}
