using CodeAgenda.Domain.Entities.Assignments;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Abstract.Assignments
{
    public interface ITagRepository
    {
        /// <summary>
        /// Add a atg in the DB.
        /// </summary>
        /// <param name="tag">Tag to add.</param>
        void AddTag(Tag tag);

        /// <summary>
        /// Gets a Tag from DB.
        /// </summary>
        /// <param name="id">Tag Id</param>
        /// <returns> Tag to exist in DB, otherwise <see langword="null"/></returns>
        Tag? Get(Guid id);

        /// <summary>
        /// Update a Tag in the DB.
        /// </summary>
        /// <param name="tag">Tag to update.</param>
        void Update(Tag tag);

        /// <summary>
        /// Delete a tag in the DB.
        /// </summary>
        /// <param name="tag">Tag to delete.</param>
        void Delete(Tag tag);
    }
}
