using Haskap.WorkflowEngine.Domain.Core.Notification.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Core.SmsNotificationTemplateAggregate
{
    public class SmsNotificationTemplate : NotificationTemplate
    {
        private List<SmsNotificationAddress> validatedGsmNumbers;


        public IEnumerable<SmsNotificationAddress> GsmNumbers
        {
            get { return validatedGsmNumbers.AsReadOnly(); }
            private set { validatedGsmNumbers = value.ToList(); }
        }
        public string Header { get; set; }

        public SmsNotificationTemplate()
        {
            validatedGsmNumbers = new List<SmsNotificationAddress>();
            //GsmNumbers = validatedGsmNumbers.AsReadOnly();
        }

        public void AddGsmNumber(SmsNotificationAddress gsmNumber)
        {
            if (gsmNumber.IsValid())
            {
                validatedGsmNumbers.Add(gsmNumber);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void UpdateGsmNumber(int index, SmsNotificationAddress gsmNumber)
        {
            if (gsmNumber.IsValid())
            {
                validatedGsmNumbers[index] = gsmNumber;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void RemoveGsmNumber(int index)
        {
            validatedGsmNumbers.RemoveAt(index);
        }

        public void RemoveGsmNumber(SmsNotificationAddress gsmNumber)
        {
            validatedGsmNumbers.Remove(validatedGsmNumbers.Find(x => x.Address == gsmNumber.Address));
        }
    }
}
