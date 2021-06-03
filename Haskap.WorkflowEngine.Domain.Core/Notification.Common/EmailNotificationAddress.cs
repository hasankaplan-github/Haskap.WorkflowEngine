using Haskap.DddBase.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Core.Notification.Common
{
    public class EmailNotificationAddress : ValueObject, INotificationAddress
    {
        private string address;

        public string Address
        {
            get { return address; }
            private set { address = value; }
        }

        public EmailNotificationAddress(string address)
        {
            this.address = address;
        }

        public static implicit operator string(EmailNotificationAddress emailNotificationAddress)
        {
            return emailNotificationAddress.address;
        }

        public static implicit operator EmailNotificationAddress(string address)
        {
            return new EmailNotificationAddress(address);
        }

        public bool IsValid()
        {
            var validator = new EmailNotificationAddressValidator();
            var validationResult = validator.Validate(this);
            return validationResult.IsValid;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Address;
        }
    }
}
