using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using CodeAgenda.Domain.Entities.Assignments;

namespace CodeAgenda.DataAccess.FluentConfigurations
{
    /// <summary>
    /// Define the configuration of <see cref="Tag"/> for EntityFrameworkCore.
    /// </summary> 
    internal class TagluentConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");
        }
    }
}

