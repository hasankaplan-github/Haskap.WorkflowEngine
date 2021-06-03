using Haskap.WorkflowEngine.Domain.Core.Notification.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Core.EmailNotificationAggregate
{
    public class EmailNotification : Notification.Common.Notification
    {
        public string Subject { get; set; }
        public ICollection<EmailNotificationAddress> ToAddresses { get; set; }
        public ICollection<EmailNotificationAddress> CcAddresses { get; set; }
        public ICollection<EmailNotificationAddress> BccAddresses { get; set; }
    }
}
