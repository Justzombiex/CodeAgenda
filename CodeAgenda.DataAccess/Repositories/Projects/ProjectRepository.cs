using CodeAgenda.DataAccess.Abstract.Projects;
using CodeAgenda.DataAccess.Abstract.Projects;
using CodeAgenda.Domain.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Repositories
{
    public partial class ApplicationRepository : IProjectRepository
    {
        /// <summary>
        /// Creates a project in DB.
        /// </summary>
        /// <param name="name">Name of the project</param>
        /// <param name="description">Description of the project</param>
        /// <param name="startDate">Start date of the project</param>
        /// <param name="endDate">End date of the project</param>
        /// <param name="userId">User associated id</param>
        public Project CreateProject(string name, string description, DateTime startDate, DateTime endDate, int userId)
        {
            Project project = new Project(name, description, startDate, endDate, userId);
            _context.Add(project);
            return project;
        }

        /// <summary>
        /// Gets a Project from DB.
        /// </summary>
        /// <param name="id">Project Id</param>
        /// <returns> Project to exist in DB, otherwise <see langword="null"/></returns>
        Project? IProjectRepository.Get(int id)
        {
            return _context.Set<Project>().Find(id);
        }

        /// <summary>
        /// Update a Project in the DB.
        /// </summary>
        /// <param name="Project">Project to update.</param>
        public void Update(Project Project)
        {
            _context.Set<Project>().Update(Project);
        }

        /// <summary>
        /// Delete a Project in the DB.
        /// </summary>
        /// <param name="Project">Project to delete.</param>
        public void Delete(Project Project)
        {
            _context.Remove(Project);
        }
    }
}
