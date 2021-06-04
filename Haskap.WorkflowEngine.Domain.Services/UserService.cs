using Haskap.DddBase.Domain.Services;
using Haskap.WorkflowEngine.Domain.Core.ProcessAggregate;
using Haskap.WorkflowEngine.Domain.Core.UserAggregate;
using Haskap.WorkflowEngine.Infrastructure.Data.NpgsqlDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Domain.Services
{
    public class UserService : DomainService
    {
        private readonly WorkflowEngineEfCoreNpgsqlDbContext workflowEngineDbContext;

        public UserService(WorkflowEngineEfCoreNpgsqlDbContext workflowEngineDbContext)
        {
            this.workflowEngineDbContext = workflowEngineDbContext;
        }
    }
}
