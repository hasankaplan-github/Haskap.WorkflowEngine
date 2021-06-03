using Haskap.WorkflowEngine.Domain.Core.PathAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Infrastructure.Data.NpgsqlDbContext.EntityTypeConfigurations
{
    public class PathEntityTypeConfiguration : BaseEntityTypeConfiguration<Path>
    {
        public override void Configure(EntityTypeBuilder<Path> builder)
        {
            base.Configure(builder);

            builder.HasMany(x => x.PathRoles)
                .WithOne()
                .HasForeignKey(x => x.PathId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.ProgressDetailMessageType)
                .HasConversion<string>();

            builder.Property(x => x.ProgressDetailOptionType)
                .HasConversion<string>();

            builder.HasMany(x => x.EmailActivities)
                .WithOne()
                .HasForeignKey(x => x.PathId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.SmsActivities)
                .WithOne()
                .HasForeignKey(x => x.PathId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
