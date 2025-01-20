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

namespace CodeAgenda.DataAccess.FluentConfigurations.Relations
{
    public class TagAndAssignmentEntityTypeConfigurationBase
        : EntityTypeConfigurationBase<TagAndAssignmentRelation>
    {
        public override void Configure(EntityTypeBuilder<TagAndAssignmentRelation> builder)
        {
            builder.ToTable("TagAndAssignments");
            base.Configure(builder);
        }
    }
}
