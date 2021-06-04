using Haskap.WorkflowEngine.Domain.Core.ProcessAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Haskap.WorkflowEngine.Domain.Core.UserAggregate
{
    public class User : AggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public ICollection<UserRole> UserRoles { get; private set; }

        private User()
        {

        }

        public User(Guid id, string firstName, string lastName)
            : base(id)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));

            UserRoles = new List<UserRole>();
        }

        public bool IsAdminOf(Process process)
        {
            if (process.AdminRoleId is null) return false;

            return UserRoles.Any(x => x.RoleId == process.AdminRoleId.Value);
        }
    }
}
