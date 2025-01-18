using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.Domain.Entities.Utils
{
    public class TagAndAssignmentRelation
    {
        public Guid PersonId { get; set; }

        public Guid AssigmentId { get; set; }

        /// <summary>
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected TagAndAssignmentRelation() { }
    }
}
