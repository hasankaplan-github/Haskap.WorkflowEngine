using Haskap.WorkflowEngine.Domain.Core.NonWorkflowActionAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Infrastructure.Data.NpgsqlDbContext.EntityTypeConfigurations
{
    public class NonWorkflowActionPermissionEntityTypeConfiguration : BaseEntityTypeConfiguration<NonWorkflowActionPermission>
    {
        public override void Configure(EntityTypeBuilder<NonWorkflowActionPermission> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => new { x.NonWorkflowActionId, x.StateId, x.RoleId });
        }
    }
}
