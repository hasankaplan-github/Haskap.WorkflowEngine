using System.Collections.Generic;

namespace Haskap.WorkflowEngine.Domain.Core.NonWorkflowActionAggregate
{
    public class NonWorkflowAction : AggregateRoot
    {
        public string CodeName { get; set; }
        public ICollection<NonWorkflowActionPermission> Permissions { get; set; }
    }
}