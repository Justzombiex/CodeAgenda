using CodeAgenda.Domain.Entities.Common;

namespace CodeAgenda.DataAccess.Abstract.Common
{
    public interface INoteRepository
    {
        /// <summary>
        /// Add a note in the DB.
        /// </summary>
        /// <param name="note">Note to add.</param>
        void Add(Note note);

        /// <summary>
        /// Gets a Note from DB.
        /// </summary>
        /// <param name="id">Note Id</param>
        /// <returns> Note to exist in DB, otherwise <see langword="null"/></returns>
        Note? GetById(Guid id);

        /// <summary>
        /// Gets all Notes from DB.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<Note> GetAll();

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
