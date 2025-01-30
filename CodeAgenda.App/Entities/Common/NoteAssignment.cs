using CodeAgenda.Domain.Entities.Assignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.Domain.Entities.Common
{
    public class NoteAssignment : Note
    {
        /// <summary>
        /// The assignment to which this note is associated.
        /// </summary>
        public Assignment Assignment { get; set; }

        /// <summary>
        /// The unique identifier of the assignment associated with this note.
        /// </summary>
        public Guid AssigmetnId { get; set; }

        // <summary>
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected NoteAssignment() {}

        public NoteAssignment(
            string content,
            Assignment assignment,
            Guid id
            ) : base(content, id)
        {
            Assignment = assignment;
            AssigmetnId = assignment.Id;
        }


    }
}
