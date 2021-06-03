using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Core.ProcessAggregate
{
    public class Process : AggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; set; }

        public Guid? AdminRoleId { get; private set; }
    }
}
