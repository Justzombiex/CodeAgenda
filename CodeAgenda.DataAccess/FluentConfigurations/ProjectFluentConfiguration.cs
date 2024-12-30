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

namespace CodeAgenda.DataAccess.FluentConfigurations
{
    /// <summary>
    /// Define the configuration of <see cref="Project"/> for EntityFrameworkCore.
    /// </summary> 
    internal class ProjectFluentConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");
        }
    }
}

