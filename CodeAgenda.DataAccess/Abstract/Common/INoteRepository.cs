using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Abstract.Common
{
    public interface INoteRepository : IRepository
    {
        /// <summary>
        /// Create a Note in the DB.
        /// </summary>
        /// <param name="content">The content of the note.</param>
        /// <param name="projectId">Associated project id</param>
        Note CreateNote(string content, int projectId);

        /// <summary>
        /// Gets a Note from DB.
        /// </summary>
        /// <param name="id">Note Id</param>
        /// <returns> Note to exist in DB, otherwise <see langword="null"/></returns>
        Note? Get(int id);

        /// <summary>
        /// Update a Note in the DB.
        /// </summary>
        /// <param name="note">Note to update.</param>
        void Update(Note note);

        /// <summary>
        /// Delete a note in the DB.
        /// </summary>
        /// <param name="note">Note to delete.</param>
        void Delete(Note note);
    }
}
