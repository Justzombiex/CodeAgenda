using CodeAgenda.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

