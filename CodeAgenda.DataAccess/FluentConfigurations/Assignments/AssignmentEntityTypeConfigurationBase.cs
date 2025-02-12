using CodeAgenda.DataAccess.FluentConfigurations.Common;
using CodeAgenda.Domain.Entities.Assignments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeAgenda.DataAccess.FluentConfigurations.Assignments
{
    public class AssignmentEntityTypeConfigurationBase
        : EntityTypeConfigurationBase<Assignment>
    {
        public override void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.ToTable("Assignments");
            builder.HasMany(a => a.Notes)
                .WithOne(n => n.Assignment);
            builder.HasMany(a => a.Tags)
                .WithOne(t => t.Assignment);

            base.Configure(builder);
        }
    }
}

