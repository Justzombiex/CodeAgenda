using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.Domain.Entities.Relations
{
    public class TagAssignmentsRelation : Entity
    {
        public Guid TagId { get; protected set; }
        public TagAssignment TagAssignment { get; set; }

        public Guid AssignmentId { get; protected set; }
        public Assignment Assignment { get; set; }

        /// <summary>
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected TagAssignmentsRelation() { }
    }
}
