using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Core.Notification.Common
{
    public abstract class NotificationTemplate : AggregateRoot
    {
        public string Content { get; set; }
        public bool IsActive { get; set; }
    }
}
