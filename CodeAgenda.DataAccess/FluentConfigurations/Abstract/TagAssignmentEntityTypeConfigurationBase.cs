using CodeAgenda.DataAccess.FluentConfigurations.Common;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.FluentConfigurations.Abstract
{
    public class TagAssignmentsRelationEntityTypeConfiguration : EntityTypeConfigurationBase<TagAssignmentsRelation>
    {
        public override void Configure(EntityTypeBuilder<TagAssignmentsRelation> builder)
        {
            builder.ToTable("TagAssignmentsRelations");

            builder.HasKey(tar => new { tar.TagId, tar.AssignmentId });

            builder.HasOne(tar => tar.TagAssignment)
                   .WithMany(ta => ta.TagAssignmentsRelations)
                   .HasForeignKey(tar => tar.TagId);

            builder.HasOne(tar => tar.Assignment)
                   .WithMany(a => a.TagAssignmentsRelations)
                   .HasForeignKey(tar => tar.AssignmentId);

            base.Configure(builder);
        }
    }
}
