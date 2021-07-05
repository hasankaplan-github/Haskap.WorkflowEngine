using Haskap.DddBase.Infrastructure.Data.EfCoreDbContexts.NpgsqlDbContext;
using Haskap.WorkflowEngine.Domain.Core.ProcessAggregate;
using Haskap.WorkflowEngine.Domain.Core.RequestAggregate;
using Haskap.WorkflowEngine.Domain.Core.StateAggregate;
using Haskap.WorkflowEngine.Domain.Core.UserAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Haskap.DddBase.Infrastructure.Mediator;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Haskap.WorkflowEngine.Infrastructure.Data.NpgsqlDbContext
{
    public class WorkflowEngineEfCoreNpgsqlDbContext : BaseEfCoreNpgsqlDbContext
    {
        private readonly IMediator mediator;

        public DbSet<State> State { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Process> Process { get; set; }
        public DbSet<Request> Request { get; set; }

        public WorkflowEngineEfCoreNpgsqlDbContext(
            DbContextOptions<WorkflowEngineEfCoreNpgsqlDbContext> options,
            IMediator mediator)
            : base(options)
        {
            this.mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(WorkflowEngineEfCoreNpgsqlDbContext).Assembly);

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            mediator.DispatchDomainEventsAsync<WorkflowEngineEfCoreNpgsqlDbContext, Guid>(this).GetAwaiter().GetResult();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await mediator.DispatchDomainEventsAsync<WorkflowEngineEfCoreNpgsqlDbContext, Guid>(this, cancellationToken);
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
