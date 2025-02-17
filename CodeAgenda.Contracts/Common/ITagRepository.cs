﻿using CodeAgenda.Domain.Entities.Common;

namespace CodeAgenda.DataAccess.Abstract.Assignments
{
    public interface ITagRepository
    {
        /// <summary>
        /// Add a atg in the DB.
        /// </summary>
        /// <param name="tag">Tag to add.</param>
        void Add(Tag tag);

        /// <summary>
        /// Gets a Tag from DB.
        /// </summary>
        /// <param name="id">Tag Id</param>
        /// <returns> Tag to exist in DB, otherwise <see langword="null"/></returns>
        Tag? GetById(Guid id);

        /// <summary>
        /// Gets all Tags from DB.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<Tag> GetAll();

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
