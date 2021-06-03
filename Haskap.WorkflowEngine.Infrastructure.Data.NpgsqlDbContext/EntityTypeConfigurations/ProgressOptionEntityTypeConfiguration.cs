using Haskap.WorkflowEngine.Domain.Core.RequestAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Infrastructure.Data.NpgsqlDbContext.EntityTypeConfigurations
{
    public class ProgressOptionEntityTypeConfiguration : BaseEntityTypeConfiguration<ProgressOption>
    {
        public override void Configure(EntityTypeBuilder<ProgressOption> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => new { x.Name, x.PathId });
        }
    }
}
