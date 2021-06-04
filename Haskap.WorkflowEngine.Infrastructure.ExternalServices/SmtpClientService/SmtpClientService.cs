using Haskap.WorkflowEngine.Domain.Core.ExternalServices.SmtpClientService;
using Haskap.WorkflowEngine.Domain.Core.Notification.Common;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Infrastructure.ExternalServices.SmtpClientService
{
    public class SmtpClientService : ISmtpClientService
    {
        private const string host = "mail.abc.com.tr";
        private const int port = 587;
        private const bool useSsl = true;
        private const string fromAddress = "no_reply@abc.com.tr";
        private const string password = "";
        private const string fromName = "Haskap Company";


        public void Send(string subject, string content, ICollection<EmailNotificationAddress> toAddresses, ICollection<EmailNotificationAddress> ccAddresses, ICollection<EmailNotificationAddress> bccAddresses)
        {
            var message = CreateMimeMessage(subject, content, toAddresses, ccAddresses, bccAddresses);

            using (var smtpClient = new MailKit.Net.Smtp.SmtpClient())
            {
                smtpClient.Connect(host, port, useSsl);
                smtpClient.Authenticate(fromAddress, password);
                smtpClient.Send(message);
                smtpClient.Disconnect(true);
            }
        }

        public async Task SendAsync(string subject, string content, ICollection<EmailNotificationAddress> toAddresses, ICollection<EmailNotificationAddress> ccAddresses, ICollection<EmailNotificationAddress> bccAddresses, CancellationToken cancellationToken = default)
        {
            var message = CreateMimeMessage(subject, content, toAddresses, ccAddresses, bccAddresses);

            using (var smtpClient = new MailKit.Net.Smtp.SmtpClient())
            {
                await smtpClient.ConnectAsync(host, port, useSsl, cancellationToken);
                await smtpClient.AuthenticateAsync(fromAddress, password, cancellationToken);
                await smtpClient.SendAsync(message, cancellationToken);
                await smtpClient.DisconnectAsync(true, cancellationToken);
            }
        }

        private static MimeMessage CreateMimeMessage(string subject, string content, ICollection<EmailNotificationAddress> toAddresses, ICollection<EmailNotificationAddress> ccAddresses, ICollection<EmailNotificationAddress> bccAddresses)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(fromName, fromAddress));
            if (toAddresses?.Count > 0) message.To.AddRange(toAddresses.Select(x => MailboxAddress.Parse(x.Address)));
            if (ccAddresses?.Count > 0) message.Cc.AddRange(ccAddresses.Select(x => MailboxAddress.Parse(x.Address)));
            if (bccAddresses?.Count > 0) message.Bcc.AddRange(bccAddresses.Select(x => MailboxAddress.Parse(x.Address)));
            message.Subject = subject;
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = content;
            message.Body = bodyBuilder.ToMessageBody();

            return message;
        }
    }
}
