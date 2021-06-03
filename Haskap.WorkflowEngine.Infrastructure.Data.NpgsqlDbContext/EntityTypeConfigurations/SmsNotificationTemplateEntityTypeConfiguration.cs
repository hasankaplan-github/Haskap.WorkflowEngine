using Haskap.WorkflowEngine.Domain.Core.Notification.Common;
using Haskap.WorkflowEngine.Domain.Core.SmsNotificationTemplateAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.WorkflowEngine.Infrastructure.Data.NpgsqlDbContext.EntityTypeConfigurations
{
    public class SmsNotificationTemplateEntityTypeConfiguration : BaseEntityTypeConfiguration<SmsNotificationTemplate>
    {
        public override void Configure(EntityTypeBuilder<SmsNotificationTemplate> builder)
        {
            base.Configure(builder); // Must call this

            var smsNotificationAddressValueComparer = new ValueComparer<IEnumerable<SmsNotificationAddress>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList().AsEnumerable()
            );

            builder
                .Property(x => x.GsmNumbers)
                .HasField("validatedGsmNumbers")
                .HasColumnName("gsm_numbers")
                .HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(x => new SmsNotificationAddress(x)).ToList())
                .Metadata
                .SetValueComparer(smsNotificationAddressValueComparer);
        }
    }
}
