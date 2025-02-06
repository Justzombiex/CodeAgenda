using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.DataAccess.Abstract.Projects
{
    public interface IProjectRepository
    {
        /// <summary>
        /// Add a Project in the DB.
        /// </summary>
        /// <param name="project">Project to add.</param>
        void Add(Project project);

        /// <summary>
        /// Gets all Project from DB.
        /// </summary>
        /// <param name="id">Project Id</param>
        /// <returns> Project to exist in DB, otherwise <see langword="null"/></returns>
        Project? GetById(Guid id);

        /// <summary>
        /// Gets all Projects from DB.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<Project> GetAll();

        /// <summary>
        /// Update a Project in the DB.
        /// </summary>
        /// <param name="Project">Project to update.</param>
        void Update(Project Project);

        /// <summary>
        /// Delete a Project in the DB.
        /// </summary>
        /// <param name="note">Project to delete.</param>
        void Delete(Project Project);
    }
}
