using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Core.Notification.Common
{
    public abstract class Notification : AggregateRoot
    {
        public string Content { get; set; }
        public DateTime SentDate { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
