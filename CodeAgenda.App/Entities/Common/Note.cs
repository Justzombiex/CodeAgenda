using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.Domain.Entities.Users;
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

        /// <summary>
        /// User who created the note
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// User's id who created the note
        /// </summary>
        public Guid UserId { get; set; }

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
            User user,
            Guid id)
            : base(id)
        {
            Content = content;
            CreatedDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;
            User = user;
            UserId = user.Id;
            
        }
    }
}
