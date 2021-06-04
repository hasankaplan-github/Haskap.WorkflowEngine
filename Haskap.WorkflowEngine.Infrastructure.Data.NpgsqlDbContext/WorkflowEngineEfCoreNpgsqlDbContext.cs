using Haskap.DddBase.Infrastructure.Data.EfCoreDbContexts.NpgsqlDbContext;
using Haskap.WorkflowEngine.Domain.Core.ProcessAggregate;
using Haskap.WorkflowEngine.Domain.Core.RequestAggregate;
using Haskap.WorkflowEngine.Domain.Core.StateAggregate;
using Haskap.WorkflowEngine.Domain.Core.UserAggregate;
using Microsoft.EntityFrameworkCore;
using System;

namespace Haskap.WorkflowEngine.Infrastructure.Data.NpgsqlDbContext
{
    public class WorkflowEngineEfCoreNpgsqlDbContext : BaseEfCoreNpgsqlDbContext
    {
        public DbSet<State> State { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Process> Process { get; set; }
        public DbSet<Request> Request { get; set; }

        public WorkflowEngineEfCoreNpgsqlDbContext(DbContextOptions<WorkflowEngineEfCoreNpgsqlDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(WorkflowEngineEfCoreNpgsqlDbContext).Assembly);

            base.OnModelCreating(builder);
        }
    }
}
