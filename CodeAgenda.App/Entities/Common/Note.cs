using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.Domain.Entities.Common
{
    public abstract class Note : Entity
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
