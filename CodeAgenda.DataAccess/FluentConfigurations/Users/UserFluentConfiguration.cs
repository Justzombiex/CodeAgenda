using CodeAgenda.DataAccess.FluentConfigurations.Common;
using CodeAgenda.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

