using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.Domain.Entities.Common
{
    public class Note : Entity
    {
        #region Properties

        /// <summary>
        /// The content of the note.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// The date when the note was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// The date when the note was last modified.
        /// </summary>
        public DateTime LastModifiedDate { get; set; }

        /// <summary>
        /// The project to which this note is associated.
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// The assignment to which this note is associated.
        /// </summary>
        public Assignment Assignment { get; set; }

        /// <summary>
        /// The unique identifier of the assignment associated with this note.
        /// </summary>
        public Guid AssigmetnId { get; set; }

        /// <summary>
        /// The unique identifier of the project associated with this note.
        /// </summary>
        public Guid ProjectId { get; set; }

        #endregion Properties

        // <summary>
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected Note() { }

        /// <summary>
        /// Initializes an instance of Note.
        /// </summary>
        /// <param name="content">The content of the note.</param>
        /// <param name="id">The unique identifier for the note.</param>
        public Note(
            string content,
            Guid id)
            : base(id)
        {
            Content = content;
            CreatedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;
        }
    }
}
