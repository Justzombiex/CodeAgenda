using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.DataAccess.Abstract.Projects;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories.Common;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.Domain.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Repositories
{
    public class CategoryRepository 
        : RepositoryBase, ICategoryRepository
    {

        public CategoryRepository(ApplicationContext context) : base(context)
        {
        }

        public void Add(Category Category)
        {
            _context.Category.Add(Category);
        }

        Category? ICategoryRepository.Get(Guid id)
        {
            return _context.Set<Category>().Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Category.ToList();
        }

        public void Update(Category Category)
        {
            _context.Category.Update(Category);
        }

        public void Delete(Category Category)
        {
            _context.Category.Remove(Category);
        }
    }
}
