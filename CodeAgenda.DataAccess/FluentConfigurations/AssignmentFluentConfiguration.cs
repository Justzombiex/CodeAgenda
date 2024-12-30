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
    /// Define the configuration of <see cref="Assignment"/> for EntityFrameworkCore.
    /// </summary> 
    internal class AssignmentFluentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.ToTable("Assignments");
        }
    }
}

