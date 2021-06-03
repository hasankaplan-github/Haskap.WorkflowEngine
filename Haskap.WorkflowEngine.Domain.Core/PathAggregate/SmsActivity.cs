using Haskap.DddBase.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Core.PathAggregate
{
    public class SmsActivity : ValueObject
    {
        public Guid PathId { get; set; }
        public Guid SmsNotificationTemplateId { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PathId;
            yield return SmsNotificationTemplateId;
        }
    }
}
