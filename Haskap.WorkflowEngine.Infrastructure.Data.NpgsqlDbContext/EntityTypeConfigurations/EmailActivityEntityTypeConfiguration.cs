using Haskap.WorkflowEngine.Domain.Core.PathAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Infrastructure.Data.NpgsqlDbContext.EntityTypeConfigurations
{
    public class EmailActivityEntityTypeConfiguration : BaseEntityTypeConfiguration<EmailActivity>
    {
        public override void Configure(EntityTypeBuilder<EmailActivity> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => new { x.PathId, x.EmailNotificationTemplateId });
        }
    }
}
