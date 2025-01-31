using CodeAgenda.DataAccess.FluentConfigurations.Common;
using CodeAgenda.Domain.Entities.Assignments;
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
    public class TagAssignmentsRelationEntityTypeConfigurationBase
        : EntityTypeConfigurationBase<TagAssignmentsRelation>
    {
        public override void Configure(EntityTypeBuilder<TagAssignmentsRelation> builder)
        {
            builder.ToTable("TagAssignmentsRelations");
            builder.HasKey(ta => new { ta.TagId, ta.AssignmentId });

            builder.HasOne(ta => ta.Assignment)
                .WithMany(a => a.TagAssignmentsRelations)
                .HasForeignKey(ta => ta.TagId);

            builder.HasOne(ta => ta.TagAssignment)
                .WithMany(t => t.TagAssignmentsRelations)
                .HasForeignKey(ta => ta.AssignmentId);

            base.Configure(builder);
        }
    }
}
