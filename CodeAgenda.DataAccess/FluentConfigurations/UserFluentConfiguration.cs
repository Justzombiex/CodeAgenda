using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Users;

namespace CodeAgenda.DataAccess.FluentConfigurations
{
    /// <summary>
    /// Define the configuration of <see cref="User"/> for EntityFrameworkCore.
    /// </summary> 
    internal class UserFluentConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
        }
    }
}

