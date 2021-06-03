using System;

namespace Haskap.WorkflowEngine.Domain.Core.RoleAggregate
{
    public class Role : Entity
    {
        public string Name { get; private set; }

        private Role()
        {

        }

        public Role(Guid id, string name)
            : base(id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
