using Haskap.WorkflowEngine.Domain.Core.EmailNotificationAggregate;
using Haskap.WorkflowEngine.Domain.Core.Notification.Common;
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
    public class EmailNotificationEntityTypeConfiguration : BaseEntityTypeConfiguration<EmailNotification>
    {
        public override void Configure(EntityTypeBuilder<EmailNotification> builder)
        {
            base.Configure(builder); // Must call this

            var emailNotificationAddressValueComparer = new ValueComparer<ICollection<EmailNotificationAddress>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList()
            );

            builder
                .Property(x => x.ToAddresses)
                //.HasField("validatedToAddresses")
                .HasColumnName("to_addresses")
                .HasConversion(
                    v => string.Join(';', v.Select(x => x.Address)),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(x => new EmailNotificationAddress(x)).ToList())
                .Metadata
                .SetValueComparer(emailNotificationAddressValueComparer);

            builder
                .Property(x => x.BccAddresses)
                //.HasField("validatedBccAddresses")
                .HasColumnName("bcc_addresses")
                .HasConversion(
                    v => string.Join(';', v.Select(x => x.Address)),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(x => new EmailNotificationAddress(x)).ToList())
                .Metadata
                .SetValueComparer(emailNotificationAddressValueComparer);

            builder
                .Property(x => x.CcAddresses)
                //.HasField("validatedCcAddresses")
                .HasColumnName("cc_addresses")
                .HasConversion(
                    v => string.Join(';', v.Select(x => x.Address)),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(x => new EmailNotificationAddress(x)).ToList())
                .Metadata
                .SetValueComparer(emailNotificationAddressValueComparer);
        }
    }
}
