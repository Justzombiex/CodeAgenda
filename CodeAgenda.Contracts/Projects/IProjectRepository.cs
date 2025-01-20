using CodeAgenda.Domain.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Abstract.Projects
{
    public interface IProjectRepository
    {
        /// <summary>
        /// Add a Project in the DB.
        /// </summary>
        /// <param name="project">Project to add.</param>
        void AddProject(Project project);

        /// <summary>
        /// Gets a Project from DB.
        /// </summary>
        /// <param name="id">Project Id</param>
        /// <returns> Project to exist in DB, otherwise <see langword="null"/></returns>
        Project? Get(Guid id);

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
