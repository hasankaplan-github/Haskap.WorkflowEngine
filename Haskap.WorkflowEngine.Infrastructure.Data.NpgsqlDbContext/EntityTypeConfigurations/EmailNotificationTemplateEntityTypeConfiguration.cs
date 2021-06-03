using Haskap.DddBase.Infrastructure.Data.EfCoreEntityTypeConfigurations;
using Haskap.WorkflowEngine.Domain.Core.EmailNotificationTemplateAggregate;
using Haskap.WorkflowEngine.Domain.Core.Notification.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBasvuru.DataAccess.Configurations.EmailNotification
{
    public class EmailNotificationTemplateEntityTypeConfiguration : BaseEntityTypeConfiguration<EmailNotificationTemplate>
    {
        public override void Configure(EntityTypeBuilder<EmailNotificationTemplate> builder)
        {
            base.Configure(builder); // Must call this

            var emailNotificationAddressValueComparer = new ValueComparer<IEnumerable<EmailNotificationAddress>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList().AsEnumerable()
            );

            builder
                .Property(x => x.ToAddresses)
                .HasField("validatedToAddresses")
                .HasColumnName("to_addresses")
                .HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(x => new EmailNotificationAddress(x)).ToList())
                .Metadata
                .SetValueComparer(emailNotificationAddressValueComparer);

            builder
                .Property(x => x.BccAddresses)
                .HasField("validatedBccAddresses")
                .HasColumnName("bcc_addresses")
                .HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(x => new EmailNotificationAddress(x)).ToList())
                .Metadata
                .SetValueComparer(emailNotificationAddressValueComparer);

            builder
                .Property(x => x.CcAddresses)
                .HasField("validatedCcAddresses")
                .HasColumnName("cc_addresses")
                .HasConversion(
                    v => string.Join(';', v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(x => new EmailNotificationAddress(x)).ToList())
                .Metadata
                .SetValueComparer(emailNotificationAddressValueComparer);
        }
    }
}
