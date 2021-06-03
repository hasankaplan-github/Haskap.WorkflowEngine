using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Core.Notification.Common
{
    public class SmsNotificationAddressValidator : AbstractValidator<SmsNotificationAddress>
    {
        public SmsNotificationAddressValidator()
        {
            RuleFor(x => x.Address)
                .NotNull()
                .NotEmpty()
                .Length(10, 10)
                .Matches(@"^\d{10}$"); // only 10 digit
        }
    }
}
