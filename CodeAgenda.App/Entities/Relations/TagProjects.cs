using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.Domain.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.Domain.Entities.Relations
{
    public class TagProjects
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public Guid TagId { get; set; }
        public Tag Tag { get; set; }

        /// <summary>
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected TagProjects() { }
    }
}
