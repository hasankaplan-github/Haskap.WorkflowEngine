using Haskap.DddBase.Domain.Core.Specifications;
using Haskap.WorkflowEngine.Domain.Core.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Core.StateAggregate.Specifications
{
    public class StartStateOfProcessSpecification : Specification<State>
    {
        private readonly Guid processId;

        public StartStateOfProcessSpecification(Guid processId)
        {
            this.processId = processId;
        }

        public override Expression<Func<State, bool>> ToExpression()
        {
            return state => state.ProcessId == this.processId && state.StateType == StateType.StartState;
        }
    }
}
