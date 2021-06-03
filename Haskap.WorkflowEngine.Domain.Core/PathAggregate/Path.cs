using Haskap.WorkflowEngine.Domain.Core.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Core.PathAggregate
{
    public class Path : AggregateRoot
    {
        public Guid FromStateId { get; private set; }
        public Guid ToStateId { get; private set; }
        public Guid ActionId { get; private set; }
        public ICollection<PathRole> PathRoles { get; set; }
        public bool HasProgressDetail { get; set; }
        public ProgressDetailFieldType ProgressDetailMessageType { get; set; }
        public ProgressDetailFieldType ProgressDetailOptionType { get; set; }
        public ICollection<EmailActivity> EmailActivities { get; set; }
        public ICollection<SmsActivity> SmsActivities { get; set; }
    }
}
