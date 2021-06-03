using Haskap.DddBase.Domain.Core;
using System;
using System.Collections.Generic;

namespace Haskap.WorkflowEngine.Domain.Core.UserAggregate
{
    public class UserRole : ValueObject
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return UserId;
            yield return RoleId;
        }

        private UserRole()
        {

        }

        public UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}
