using CodeAgenda.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeAgenda.DataAccess.FluentConfigurations.Common
{
    public class NoteProjectEntityTypeConfigurationBase
        : IEntityTypeConfiguration<NoteProject>
    {
        public void Configure(EntityTypeBuilder<NoteProject> builder)
        {
            builder.ToTable("NoteProjects");
            builder.HasBaseType(typeof(Note));
        }
    }
}
