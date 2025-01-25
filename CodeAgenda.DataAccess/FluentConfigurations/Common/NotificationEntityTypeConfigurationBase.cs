using CodeAgenda.Domain.Entities.Projects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.Domain.Entities.Assignments;

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
