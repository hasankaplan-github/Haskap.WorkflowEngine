using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Core.Notification.Common
{
    public class EmailNotificationAddressValidator : AbstractValidator<EmailNotificationAddress>
    {
        public EmailNotificationAddressValidator()
        {
            Regex regex = new Regex(@"{{.*}}");
            RuleFor(x => x.Address)
                .EmailAddress().When(x => regex.IsMatch(x) == false);
        }
    }
}
