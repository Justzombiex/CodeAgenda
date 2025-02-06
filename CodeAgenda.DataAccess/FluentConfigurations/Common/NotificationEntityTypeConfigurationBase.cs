using CodeAgenda.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeAgenda.DataAccess.FluentConfigurations.Common
{
    public class NotificationEntityTypeConfigurationBase
        : EntityTypeConfigurationBase<Notification>
    {
        public override void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");
            base.Configure(builder);
        }
    }
}
