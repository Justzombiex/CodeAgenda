using CodeAgenda.DataAccess.Abstract.Assignments;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories.Common;
using CodeAgenda.Domain.Entities.Assignments;

namespace CodeAgenda.DataAccess.Repositories
{
    public class TagRepository
        : RepositoryBase, ITagRepository
    {
        public TagRepository(ApplicationContext context) : base(context)
        {
        }

        public void Add(Tag Tag)
        {
            _context.Tag.Add(Tag);
        }

        Tag? ITagRepository.GetById(Guid id)
        {
            var tag = _context.Tag.FirstOrDefault(x => x.Id == id);
            if (tag == null)
            {
                throw new Exception("Tag not found");
            }
            return tag;
        }

        public IEnumerable<Tag> GetAll()
        {
            return _context.Tag.ToList();
        }

        public void Update(Tag Tag)
        {
            _context.Tag.Update(Tag);
        }

        public void Delete(Tag Tag)
        {
            _context.Tag.Remove(Tag);
        }


    }
}
