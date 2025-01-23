using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.Domain.Entities.Relations
{
    public class TagAssignments
    {
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }

        public Guid AssignmentId { get; set; }
        public Assignment Assignment { get; set; }

        /// <summary>
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected TagAssignments() { }
    }
}
