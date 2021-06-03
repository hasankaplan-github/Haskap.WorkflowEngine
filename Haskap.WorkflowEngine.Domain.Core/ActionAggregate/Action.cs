using Haskap.WorkflowEngine.Domain.Core.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Core.ActionAggregate
{
    public class Action : AggregateRoot
    {
        public string Name { get; private set; }
        public Guid? ProcessId { get; private set; }
        //public Process Process { get; private set; }
        public ActionType ActionType { get; private set; }

    }
}
