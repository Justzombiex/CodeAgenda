using CodeAgenda.DataAccess.FluentConfigurations.Common;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.FluentConfigurations.Projects
{
    public class CategoryEntityTypeConfigurationBase
        : EntityTypeConfigurationBase<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.Property(t => t.Color)
               .HasConversion(
               c => c.ToArgb(),
               s => Color.FromArgb(s));
            base.Configure(builder);
        }
    }
}
