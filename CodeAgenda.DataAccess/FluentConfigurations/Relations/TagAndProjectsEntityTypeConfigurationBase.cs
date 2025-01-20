using CodeAgenda.DataAccess.FluentConfigurations.Common;
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
    public class TagAndProjectEntityTypeConfigurationBase
        : EntityTypeConfigurationBase<TagAndProjectRelation>
    {
        public override void Configure(EntityTypeBuilder<TagAndProjectRelation> builder)
        {
            builder.ToTable("TagAndProjects");
            base.Configure(builder);
        }
    }
}
