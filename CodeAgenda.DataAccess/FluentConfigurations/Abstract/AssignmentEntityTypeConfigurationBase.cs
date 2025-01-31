using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.DataAccess.FluentConfigurations.Common;
using CodeAgenda.Domain.Entities.Relations;

namespace CodeAgenda.DataAccess.FluentConfigurations.Abstract
{
    public class AssignmentEntityTypeConfigurationBase
        : EntityTypeConfigurationBase<Assignment>
    {
        public override void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.ToTable("Assignments");
            builder.HasMany(a => a.Notes)
                .WithOne(n => n.Assignment);

            builder.HasMany(a => a.TagAssignmentsRelations)
                .WithOne(t => t.Assignment)
                .HasForeignKey(ta => ta.AssignmentId);
                

            base.Configure(builder);
        }
    }
}

