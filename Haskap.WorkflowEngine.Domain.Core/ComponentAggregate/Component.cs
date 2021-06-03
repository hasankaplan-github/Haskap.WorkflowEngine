using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Core.ComponentAggregate
{
    public class Component : AggregateRoot
    {
        public string Name { get; set; }
        public ICollection<ComponentPermission> ComponentPermissions { get; set; }
    }
}
