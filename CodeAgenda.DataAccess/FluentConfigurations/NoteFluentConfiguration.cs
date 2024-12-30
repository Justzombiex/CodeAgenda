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

namespace CodeAgenda.DataAccess.FluentConfigurations
{
    /// <summary>
    /// Define the configuration of <see cref="Note/> for EntityFrameworkCore.
    /// </summary> 
    internal class NoteFluentConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Notes");
        }
    }
}

