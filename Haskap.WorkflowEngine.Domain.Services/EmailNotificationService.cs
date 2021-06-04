using Haskap.DddBase.Domain.Services;
using Haskap.WorkflowEngine.Domain.Core.EmailNotificationAggregate;
using Haskap.WorkflowEngine.Domain.Core.ExternalServices.SmtpClientService;
using Haskap.WorkflowEngine.Domain.Core.Notification.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Services
{
    public class EmailNotificationService : DomainService
    {
        private readonly ISmtpClientService smtpClientService;

        public EmailNotificationService(ISmtpClientService smtpClientService)
        {
            this.smtpClientService = smtpClientService;
        }

        public bool SendNotification(Notification notification)
        {
            bool isSuccessful = false;

            try
            {
                if (notification is EmailNotification emailNotification)
                {
                    smtpClientService.Send(emailNotification.Subject, emailNotification.Content, emailNotification.ToAddresses, emailNotification.CcAddresses, emailNotification.BccAddresses);
                    isSuccessful = true;
                    emailNotification.IsSuccessful = true;
                    emailNotification.SentDate = DateTime.Now;
                }
            }
            catch (Exception)
            {
            }

            return isSuccessful;
        }

        public async Task<bool> SendNotificationAsync(Notification notification, CancellationToken cancellationToken = default)
        {
            bool isSuccessful = false;

            try
            {
                if (notification is EmailNotification emailNotification)
                {
                    await smtpClientService.SendAsync(emailNotification.Subject, emailNotification.Content, emailNotification.ToAddresses, emailNotification.CcAddresses, emailNotification.BccAddresses, cancellationToken);
                    isSuccessful = true;
                    emailNotification.IsSuccessful = true;
                    emailNotification.SentDate = DateTime.Now;
                }
            }
            catch (Exception)
            {
            }

            return isSuccessful;
        }
    }
}
