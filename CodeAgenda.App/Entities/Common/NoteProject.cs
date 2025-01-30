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
    public class NoteProject : Note
    {
        /// <summary>
        /// The project to which this note is associated.
        /// </summary>
        public Project Project { get; set; }


        /// <summary>
        /// The unique identifier of the project associated with this note.
        /// </summary>
        public Guid ProjectId { get; protected set; }

        // <summary>
        /// Required by EntityFrameworkCore for migration.
        /// </summary>
        protected NoteProject() { }

        public NoteProject(
            string content,
            User user,
            Project project,
            Guid id
            ) : base(content, user, id)
        {
            Project = project;
            ProjectId = project.Id;
        }
    }
}
