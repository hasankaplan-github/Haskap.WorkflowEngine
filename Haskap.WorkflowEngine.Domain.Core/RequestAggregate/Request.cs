using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Core.RequestAggregate
{
    public class Request : AggregateRoot
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid? ProcessId { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? CurrentStateId { get; set; }
        public ICollection<Progress> Progresses { get; set; }

        private Request()
        {
            
        }

        public Request(Guid id, string title, string description, Guid processId, Guid ownerId, Guid currentStateId)
            : base(id)
        {
            Id = id;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description;
            ProcessId = processId;
            OwnerId = ownerId;
            CurrentStateId = currentStateId;
            Progresses = new List<Progress>();
        }
    }
}
