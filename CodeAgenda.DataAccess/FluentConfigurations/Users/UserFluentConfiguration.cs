using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Users;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.DataAccess.FluentConfigurations.Common;
using CodeAgenda.Domain.Entities.Common;

namespace CodeAgenda.DataAccess.FluentConfigurations.Users
{
    /// <summary>
    /// Define the configuration of <see cref="User"/> for EntityFrameworkCore.
    /// </summary> 
    public class UserEntityTypeConfigurationBase
        : EntityTypeConfigurationBase<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasMany(u => u.Projects)
                .WithOne(p => p.User);
            builder.HasMany(u => u.Notes)
                .WithOne(n => n.User);
            base.Configure(builder);
        }
    }
}

