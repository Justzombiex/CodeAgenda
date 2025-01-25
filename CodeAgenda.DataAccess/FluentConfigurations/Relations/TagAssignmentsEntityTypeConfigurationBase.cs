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
    public class TagAssignmentsEntityTypeConfigurationBase :IEntityTypeConfiguration<TagAssignments>
    {
        public void Configure(EntityTypeBuilder<TagAssignments> builder)
        {
            builder.ToTable("TagAssignments");
            builder.HasKey(ta => new { ta.TagId, ta.AssignmentId });
        }
    }
}
