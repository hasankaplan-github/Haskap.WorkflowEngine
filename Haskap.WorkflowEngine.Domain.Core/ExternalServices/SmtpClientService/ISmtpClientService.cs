using Haskap.WorkflowEngine.Domain.Core.Notification.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Core.ExternalServices.SmtpClientService
{
    public interface ISmtpClientService
    {
        void Send(string subject, string content, ICollection<EmailNotificationAddress> toAddresses, ICollection<EmailNotificationAddress> ccAddresses, ICollection<EmailNotificationAddress> bccAddresses);
        Task SendAsync(string subject, string content, ICollection<EmailNotificationAddress> toAddresses, ICollection<EmailNotificationAddress> ccAddresses, ICollection<EmailNotificationAddress> bccAddresses, CancellationToken cancellationToken = default);
    }
}
