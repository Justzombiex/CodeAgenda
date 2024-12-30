using CodeAgenda.Domain.Entities.Projects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAgenda.Domain.Entities.Common;

namespace CodeAgenda.DataAccess.FluentConfigurations
{
    
        /// <summary>
        /// Define the configuration of <see cref="Notification"/> for EntityFrameworkCore.
        /// </summary> 
        internal class NotificationFluentConfiguration : IEntityTypeConfiguration<Notification>
        {
            public void Configure(EntityTypeBuilder<Notification> builder)
            {
                builder.ToTable("Notifications");
            }
        }
    
}
