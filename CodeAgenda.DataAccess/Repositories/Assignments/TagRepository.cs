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
            return _context.Set<Tag>().Find(id);
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
