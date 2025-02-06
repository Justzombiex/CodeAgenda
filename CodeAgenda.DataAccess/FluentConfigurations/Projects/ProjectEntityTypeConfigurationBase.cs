using CodeAgenda.DataAccess.FluentConfigurations.Common;
using CodeAgenda.Domain.Entities.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeAgenda.DataAccess.FluentConfigurations.Projects
{
    public class ProjectEntityTypeConfigurationBase
        : EntityTypeConfigurationBase<Project>
    {
        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            builder.HasMany(a => a.Assignments)
                .WithOne(p => p.Project);
            builder.HasMany(n => n.Notes)
                .WithOne(p => p.Project);
            builder.HasOne(c => c.Category)
                .WithOne(p => p.Project);
            builder.HasMany(p => p.Tags)
                .WithOne(p => p.Project);

            base.Configure(builder);
        }
    }
}

