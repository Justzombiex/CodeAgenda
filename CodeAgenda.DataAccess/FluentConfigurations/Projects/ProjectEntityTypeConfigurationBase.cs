using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.DataAccess.FluentConfigurations.Common;
using CodeAgenda.Domain.Entities.Relations;

namespace CodeAgenda.DataAccess.FluentConfigurations.Projects
{
    public class ProjectEntityTypeConfigurationBase
        : EntityTypeConfigurationBase<Project>
    {
        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            builder.HasMany(a => a.Assignments)
                .WithOne(p => p.Project);
            builder.HasMany(n => n.Notes)
                .WithOne(p => p.Project);
            builder.HasOne(c => c.Category)
                .WithOne(p => p.Project);

            builder.HasMany(a => a.TagProjectsRelations)
                 .WithOne(t => t.Project)
                 .HasForeignKey(ta => ta.ProjectId);



            base.Configure(builder);
        }
    }
}

