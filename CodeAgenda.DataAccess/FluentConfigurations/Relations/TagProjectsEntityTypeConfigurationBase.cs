using CodeAgenda.DataAccess.FluentConfigurations.Common;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.Domain.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.FluentConfigurations.Relations
{
    public class TagProjectsEntityTypeConfigurationBase : IEntityTypeConfiguration<TagProjects>
    {
        public void Configure(EntityTypeBuilder<TagProjects> builder)
        {
            builder.ToTable("TagProjects");
            builder.HasKey(ta => new { ta.TagId, ta.ProjectId });
        }
    }
}
