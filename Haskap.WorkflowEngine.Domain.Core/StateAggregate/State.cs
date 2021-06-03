using Haskap.WorkflowEngine.Domain.Core.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Core.StateAggregate
{
    public class State : AggregateRoot
    {
        public string Name { get; private set; }
        public Guid? ProcessId { get; private set; }
        public StateType StateType { get; private set; }
    }
}
