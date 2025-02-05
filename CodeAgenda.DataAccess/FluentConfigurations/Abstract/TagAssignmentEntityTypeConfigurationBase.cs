using CodeAgenda.DataAccess.FluentConfigurations.Common;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.FluentConfigurations.Abstract
{
    public class TagAssignmentsEntityTypeConfiguration
    : IEntityTypeConfiguration<TagAssignment>
    {
        public void Configure(EntityTypeBuilder<TagAssignment> builder)
        {
            builder.ToTable("TagAssignments");
            builder.HasBaseType(typeof(Tag));

            builder.Property(t => t.Color)
            .HasConversion(
            c => c.ToArgb(),
            s => Color.FromArgb(s));

        }
    }
}

