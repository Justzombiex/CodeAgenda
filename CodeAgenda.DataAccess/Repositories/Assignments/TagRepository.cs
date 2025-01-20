using CodeAgenda.DataAccess.Abstract.Assignments;
using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories.Common;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Repositories
{
    public class TagRepository 
        : RepositoryBase, ITagRepository
    {
        public TagRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddTag(Tag Tag)
        {
            _context.Tag.Add(Tag);
        }

        /// <summary>
        /// Gets a Tag from DB.
        /// </summary>
        /// <param name="id">Tag Id</param>
        /// <returns> Tag to exist in DB, otherwise <see langword="null"/></returns>
        Tag? ITagRepository.Get(Guid id)
        {
            return _context.Set<Tag>().Find(id);
        }

        /// <summary>
        /// Update a Tag in the DB.
        /// </summary>
        /// <param name="Tag">Tag to update.</param>
        public void Update(Tag Tag)
        {
            _context.Tag.Update(Tag);
        }

        /// <summary>
        /// Delete a Tag in the DB.
        /// </summary>
        /// <param name="Tag">Tag to delete.</param>
        public void Delete(Tag Tag)
        {
            _context.Tag.Remove(Tag);
        }

    }
}
