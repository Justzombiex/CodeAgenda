using CodeAgenda.DataAccess.FluentConfigurations.Common;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeAgenda.DataAccess.FluentConfigurations.Abstract
{
    public class TagProjectEntityTypeConfigurationBase
        : EntityTypeConfigurationBase<TagProject>
    {
        public override void Configure(EntityTypeBuilder<TagProject> builder)
        {
            builder.ToTable("TagProjects");
            builder.HasMany(t => t.TagProjectRelations)
                .WithOne(tp => tp.TagProject)
                .HasForeignKey(tp => tp.TagId);

            base.Configure(builder);
        }
    }
}