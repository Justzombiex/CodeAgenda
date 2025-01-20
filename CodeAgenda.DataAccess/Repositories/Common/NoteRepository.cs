using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories.Common;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Repositories
{
    public class NoteRepository 
        :RepositoryBase, INoteRepository 
    {

        public NoteRepository(ApplicationContext context) : base(context)
        {
        }
        public void AddNote(Note Note)
        {
            _context.Note.Add(Note);
        }

        /// <summary>
        /// Gets a Note from DB.
        /// </summary>
        /// <param name="id">Note Id</param>
        /// <returns> Note to exist in DB, otherwise <see langword="null"/></returns>
        Note? INoteRepository.Get(Guid id)
        {
            return _context.Set<Note>().Find(id);
        }

        /// <summary>
        /// Update a Note in the DB.
        /// </summary>
        /// <param name="Note">Note to update.</param>
        public void Update(Note Note)
        {
            _context.Note.Update(Note);
        }

        /// <summary>
        /// Delete a Note in the DB.
        /// </summary>
        /// <param name="Note">Note to delete.</param>
        public void Delete(Note Note)
        {
            _context.Note.Remove(Note);
        }
    }
}
