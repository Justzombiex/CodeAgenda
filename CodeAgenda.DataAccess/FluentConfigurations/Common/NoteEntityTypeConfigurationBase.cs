using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CodeAgenda.Domain.Entities.Common;

namespace CodeAgenda.DataAccess.FluentConfigurations.Common
{
    public class NoteEntityTypeConfigurationBase
        : EntityTypeConfigurationBase<Note>
    {
        public override void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Notes");
            base.Configure(builder);
        }
    }
}

