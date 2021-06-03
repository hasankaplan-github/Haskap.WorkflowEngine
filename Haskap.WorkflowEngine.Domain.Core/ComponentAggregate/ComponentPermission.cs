using Haskap.WorkflowEngine.Domain.Core.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Core.ComponentAggregate
{
    public class ComponentPermission : Entity
    {
        public Guid ComponentId { get; set; }
        public Guid StateId { get; set; }
        public Guid RoleId { get; set; }
        public bool HasReadPermission { get; set; }
        public bool HasWritePermission { get; set; }
        public ComponentSaveType ComponentSaveType { get; set; }
    }
}
