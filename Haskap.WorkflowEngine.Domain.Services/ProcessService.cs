using Haskap.DddBase.Domain.Services;
using Haskap.WorkflowEngine.Domain.Core.RequestAggregate;
using Haskap.WorkflowEngine.Domain.Core.StateAggregate;
using Haskap.WorkflowEngine.Domain.Core.StateAggregate.Specifications;
using Haskap.WorkflowEngine.Infrastructure.Data.NpgsqlDbContext;
using System;
using System.Linq;
using Utilities.Guids;

namespace Haskap.WorkflowEngine.Domain.Services
{
    public class ProcessService : DomainService
    {
        private readonly WorkflowEngineEfCoreNpgsqlDbContext workflowEngineDbContext;

        public ProcessService(WorkflowEngineEfCoreNpgsqlDbContext workflowEngineDbContext)
        {
            this.workflowEngineDbContext = workflowEngineDbContext;
        }

        public State GetStartStateOfProcess(Guid processId)
        {
            return workflowEngineDbContext.State
                .Single(new StartStateOfProcessSpecification(processId));
        }

        public Request CreateRequest(string title, string description, Guid processId, Guid ownerId)
        {
            using (var transaction = workflowEngineDbContext.Database.BeginTransaction())
            {
                try
                {
                    var startState = GetStartStateOfProcess(processId);
                    var requestId = GuidGenerator.CreateSequentialGuid(SequentialGuidType.SequentialAsString);
                    var request = new Request(requestId, title, description, processId, ownerId, startState.Id);
                    workflowEngineDbContext.Request.Add(request);
                    workflowEngineDbContext.SaveChanges();
                    transaction.Commit();
                    return request;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

    }
}
