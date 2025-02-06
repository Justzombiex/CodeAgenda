using CodeAgenda.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeAgenda.DataAccess.FluentConfigurations.Common
{
    public class NoteAssignmentEntityTypeConfigurationBase
        : IEntityTypeConfiguration<NoteAssignment>
    {
        public void Configure(EntityTypeBuilder<NoteAssignment> builder)
        {
            builder.ToTable("NoteAssignments");
            builder.HasBaseType(typeof(Note));
        }
    }
}

