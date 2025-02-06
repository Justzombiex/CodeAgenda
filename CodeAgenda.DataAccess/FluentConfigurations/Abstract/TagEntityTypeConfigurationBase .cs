using CodeAgenda.DataAccess.FluentConfigurations.Common;
using CodeAgenda.Domain.Entities.Assignments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;

namespace CodeAgenda.DataAccess.FluentConfigurations.Abstract
{
    public class TagEntityTypeConfigurationBase
        : EntityTypeConfigurationBase<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");

            builder.Property(t => t.Color)
                   .HasConversion(
                   c => c.ToArgb(),
                   s => Color.FromArgb(s));

            base.Configure(builder);
        }
    }
}

