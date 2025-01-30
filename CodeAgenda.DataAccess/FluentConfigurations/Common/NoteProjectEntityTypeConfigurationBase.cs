using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CodeAgenda.Domain.Entities.Common;

namespace CodeAgenda.DataAccess.FluentConfigurations.Common
{
    public class NoteProjectEntityTypeConfigurationBase
        : EntityTypeConfigurationBase<NoteProject>
    {
        public override void Configure(EntityTypeBuilder<NoteProject> builder)
        {
            builder.ToTable("NoteProjects");
            builder.HasBaseType(typeof(Note));
        }
    }
}
