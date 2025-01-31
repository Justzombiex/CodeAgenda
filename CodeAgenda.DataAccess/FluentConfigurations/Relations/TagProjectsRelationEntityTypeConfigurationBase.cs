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
    public class TagProjectsRelationEntityTypeConfigurationBase 
        :EntityTypeConfigurationBase<TagProjectsRelation>
    {
        public override void Configure(EntityTypeBuilder<TagProjectsRelation> builder)
        {
            builder.ToTable("TagProjectsRelations");
            builder.HasKey(tp => new { tp.TagId, tp.ProjectId });

            builder.HasOne(tp => tp.TagProject)
                .WithMany(t => t.TagProjectRelations)
                .HasForeignKey(t => t.TagId);

            builder.HasOne(ta => ta.Project)
                .WithMany(t => t.TagProjectsRelations)
                .HasForeignKey(ta => ta.ProjectId);

            base.Configure(builder);

        }
    }
}
