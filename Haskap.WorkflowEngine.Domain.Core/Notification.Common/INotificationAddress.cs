using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Core.Notification.Common
{
    public interface INotificationAddress
    {
        string Address { get; }
        bool IsValid();
    }
}
