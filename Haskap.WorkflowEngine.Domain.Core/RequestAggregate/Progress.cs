using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Core.RequestAggregate
{
    public class Progress : Entity
    {
        public Guid RequestId { get; set; }
        public Guid? PathId { get; set; }
        public DateTime ProgressDate { get; set; }
        public string Message { get; set; }
        public ProgressOption Option { get; set; }
    }
}
