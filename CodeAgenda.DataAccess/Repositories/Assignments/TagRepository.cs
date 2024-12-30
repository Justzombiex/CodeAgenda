using CodeAgenda.DataAccess.Abstract.Assignments;
using CodeAgenda.Domain.Entities.Assignments;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Repositories
{
    public partial class ApplicationRepository : ITagRepository
    {
        /// <summary>
        /// Create a Tag in the DB.
        /// </summary>
        /// <param name="name">The name of the tag.</param>
        /// <param name="color">The color associated to the tag</param>
        /// <returns></returns>
        public Tag CreateTag(string name, Color color)
        {
            Tag tag = new Tag(name, color);
            _context.Add(tag);
            return tag;
        }

        Tag? ITagRepository.Get(int id)
        {
            return _context.Set<Tag>().Find(id);
        }

        public void Update(Tag tag)
        {
            
            _context.Set<Tag>().Update(tag);
        }

        public void Delete(Tag tag)
        {
            _context.Remove(tag);
        }

    }
}
