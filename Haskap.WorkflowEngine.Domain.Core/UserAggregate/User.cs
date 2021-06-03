using System;
using System.Collections.Generic;

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
    }
}
