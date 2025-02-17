﻿using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Users;

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
        public Guid AssignmentId { get; set; }

        // <summary>
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected NoteAssignment() { }

        public NoteAssignment(
            string content,
            User user,
            Assignment assignment,
            Guid id
            ) : base(content, user, id)
        {
            Assignment = assignment;
            AssignmentId = assignment.Id;
        }


    }
}
