using Haskap.DddBase.Infrastructure.Data.EfCoreDbContexts.NpgsqlDbContext;
using Microsoft.EntityFrameworkCore;
using System;

namespace Haskap.WorkflowEngine.Infrastructure.Data.NpgsqlDbContext
{
    public class WorkflowEngineEfCoreNpgsqlDbContext : BaseEfCoreNpgsqlDbContext
    {

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
