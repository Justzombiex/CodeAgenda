using CodeAgenda.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.Domain.Entities.Relations
{
    public class TagAndProjectRelation : Entity
    {
        public Guid ProjectId { get; set; }

        public Guid TagId { get; set; }

        /// <summary>
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected TagAndProjectRelation() { }
    }
}
