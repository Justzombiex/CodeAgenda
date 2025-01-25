using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using CodeAgenda.Domain.Entities.Assignments;
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

