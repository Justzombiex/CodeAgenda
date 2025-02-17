using CodeAgenda.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;

namespace CodeAgenda.DataAccess.FluentConfigurations.Common
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

