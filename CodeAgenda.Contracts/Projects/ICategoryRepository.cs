using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.DataAccess.Abstract.Projects
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Add a Category in the DB.
        /// </summary>
        /// <param name="category">Category to add.</param>
        void Add(Category category);

        /// <summary>
        /// Gets a Category from DB.
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns> Category to exist in DB, otherwise <see langword="null"/></returns>
        Category? GetById(Guid id);

        /// <summary>
        /// Gets all Categories from DB.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<Category> GetAll();

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
