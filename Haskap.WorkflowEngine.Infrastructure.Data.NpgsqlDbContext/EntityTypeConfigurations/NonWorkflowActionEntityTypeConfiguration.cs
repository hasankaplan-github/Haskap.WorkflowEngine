using Haskap.WorkflowEngine.Domain.Core.NonWorkflowActionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Infrastructure.Data.NpgsqlDbContext.EntityTypeConfigurations
{
    public class NonWorkflowActionEntityTypeConfiguration : BaseEntityTypeConfiguration<NonWorkflowAction>
    {
        public override void Configure(EntityTypeBuilder<NonWorkflowAction> builder)
        {
            base.Configure(builder);

            builder.HasMany(x => x.Permissions)
                .WithOne()
                .HasForeignKey(x => x.NonWorkflowActionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
