using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.DataAccess.Abstract.Projects;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories.Common;
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

        public void AddCategory(Category Category)
        {
            _context.Category.Add(Category);
        }

        /// <summary>
        /// Gets a Category from DB.
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns> Category to exist in DB, otherwise <see langword="null"/></returns>
        Category? ICategoryRepository.Get(Guid id)
        {
            return _context.Set<Category>().Find(id);
        }

        /// <summary>
        /// Update a Category in the DB.
        /// </summary>
        /// <param name="Category">Category to update.</param>
        public void Update(Category Category)
        {
            _context.Category.Update(Category);
        }

        /// <summary>
        /// Delete a Category in the DB.
        /// </summary>
        /// <param name="Category">Category to delete.</param>
        public void Delete(Category Category)
        {
            _context.Category.Remove(Category);
        }
    }
}
