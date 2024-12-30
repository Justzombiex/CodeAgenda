using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Repositories
{
    public partial class ApplicationRepository : INoteRepository 
    {
        /// <summary>
        /// Create a Note in the DB.
        /// </summary>
        /// <param name="content">The content of the note.</param>
        public Note CreateNote(string content, int projectId)
        {
            Note note = new Note(content, projectId);
            _context.Add(note);
            return note;
        }

        /// <summary>
        /// Gets a Note from DB.
        /// </summary>
        /// <param name="id">Note Id</param>
        /// <returns> Note to exist in DB, otherwise <see langword="null"/></returns>
        Note? INoteRepository.Get(int id)
        {
            return _context.Set<Note>().Find(id);
        }

        /// <summary>
        /// Update a Note in the DB.
        /// </summary>
        /// <param name="note">Note to update.</param>
        public void Update(Note note)
        {
            _context.Set<Note>().Update(note);
        }

        /// <summary>
        /// Delete a note in the DB.
        /// </summary>
        /// <param name="note">Note to delete.</param>
        public void Delete(Note note)
        {
            _context.Remove(note);
        }
    }
}
