using CodeAgenda.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;

namespace CodeAgenda.DataAccess.FluentConfigurations.Common
{
    public class TagProjectsEntityTypeConfiguration
        : IEntityTypeConfiguration<TagProject>
    {
        public void Configure(EntityTypeBuilder<TagProject> builder)
        {
            builder.ToTable("TagProjects");

            builder.Property(t => t.Color)
                .HasConversion(
                c => c.ToArgb(),
                s => Color.FromArgb(s));

            builder.HasBaseType(typeof(Tag));

        }
    }
}