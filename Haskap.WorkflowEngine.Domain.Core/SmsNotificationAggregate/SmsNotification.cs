using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haskap.WorkflowEngine.Domain.Core.Notification.Common;

namespace Haskap.WorkflowEngine.Domain.Core.SmsNotificationAggregate
{
    public class SmsNotification : Notification.Common.Notification
    {
        public ICollection<SmsNotificationAddress> GsmNumbers { get; set; }
        public string Header { get; set; }
    }
}
