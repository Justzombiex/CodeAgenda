using CodeAgenda.Domain.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Abstract.Categorys
{
    public interface ICategoryRepository : IRepository
    {
        /// <summary>
        /// Creates a category in DB.
        /// </summary>
        /// <param name="name">The name of the category.</param>
        /// <param name="color">The color associated with the category.</param>
        Category CreateCategory(string name, Color color, int projectId);

        /// <summary>
        /// Gets a Category from DB.
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns> Category to exist in DB, otherwise <see langword="null"/></returns>
        Category? Get(int id);

        /// <summary>
        /// Update a Category in the DB.
        /// </summary>
        /// <param name="Category">Category to update.</param>
        void Update(Category Category);

        /// <summary>
        /// Delete a Category in the DB.
        /// </summary>
        /// <param name="note">Category to delete.</param>
        void Delete(Category Category);

    }
}
