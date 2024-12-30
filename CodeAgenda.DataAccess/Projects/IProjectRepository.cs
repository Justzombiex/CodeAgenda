using CodeAgenda.Domain.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Abstract.Projects
{
    public interface IProjectRepository : IRepository
    {
        /// <summary>
        /// Creates a project in DB.
        /// </summary>
        /// <param name="name">Name of the project</param>
        /// <param name="description">Description of the project</param>
        /// <param name="startDate">Start date of the project</param>
        /// <param name="endDate">End date of the project</param>
        /// <param name="userId">User associated id</param>
        Project CreateProject(string name, string description, DateTime startDate, DateTime endDate, int userId);

        /// <summary>
        /// Gets a Project from DB.
        /// </summary>
        /// <param name="id">Project Id</param>
        /// <returns> Project to exist in DB, otherwise <see langword="null"/></returns>
        Project? Get(int id);

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
