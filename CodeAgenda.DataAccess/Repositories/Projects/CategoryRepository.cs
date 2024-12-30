using CodeAgenda.DataAccess.Abstract.Categorys;
using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.DataAccess.Abstract.Projects;
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
    public partial class ApplicationRepository : ICategoryRepository
    {
        /// <summary>
        /// Creates a category in DB.
        /// </summary>
        /// <param name="name">The name of the category.</param>
        /// <param name="color">The color associated with the category.</param>
        /// <param name="projectId">project associated id</param>
        public Category CreateCategory(string name, Color color, int projectId)
        {
            Category category = new Category(name, color, projectId);
            _context.Add(category);
            return category;
        }

        /// <summary>
        /// Gets a Category from DB.
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns> Category to exist in DB, otherwise <see langword="null"/></returns>
        Category? ICategoryRepository.Get(int id)
        {
            return _context.Set<Category>().Find(id);
        }

        /// <summary>
        /// Update a Category in the DB.
        /// </summary>
        /// <param name="Category">Category to update.</param>
        public void Update(Category Category)
        {
            _context.Set<Category>().Update(Category);
        }

        /// <summary>
        /// Delete a Category in the DB.
        /// </summary>
        /// <param name="Category">Category to delete.</param>
        public void Delete(Category Category)
        {
            _context.Remove(Category);
        }
    }
}
