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
    public class TagProjectsRelation : Entity
    {
        public Guid ProjectId { get; protected set; }
        public Project Project { get; set; }

        public Guid TagId { get; protected set; }
        public TagProject TagProject { get; set; }

        /// <summary>
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected TagProjectsRelation() {}
    }
}
