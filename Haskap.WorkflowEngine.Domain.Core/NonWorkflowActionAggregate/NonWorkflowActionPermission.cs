using Haskap.DddBase.Domain.Core;
using System.Collections.Generic;
using System;
using Utilities.Guids;

namespace Haskap.WorkflowEngine.Domain.Core.NonWorkflowActionAggregate
{
    public class NonWorkflowActionPermission : ValueObject
    {
        public Guid NonWorkflowActionId { get; }
        public Guid StateId { get; }
        public Guid RoleId { get; }

        public NonWorkflowActionPermission(Guid nonWorkflowActionId, Guid stateId, Guid roleId)
        {
            NonWorkflowActionId = nonWorkflowActionId;
            StateId = stateId;
            RoleId = roleId;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return NonWorkflowActionId;
            yield return StateId;
            yield return RoleId;
        }
    }
}