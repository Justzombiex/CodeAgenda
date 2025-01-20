using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.DataAccess.Abstract.Projects;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories.Common;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.Domain.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DataAccess.Repositories
{
    public class ProjectRepository 
        : RepositoryBase, IProjectRepository
    {
        public ProjectRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddProject(Project Project)
        {
            _context.Project.Add(Project);
        }

        /// <summary>
        /// Gets a Project from DB.
        /// </summary>
        /// <param name="id">Project Id</param>
        /// <returns> Project to exist in DB, otherwise <see langword="null"/></returns>
        Project? IProjectRepository.Get(Guid id)
        {
            return _context.Set<Project>().Find(id);
        }

        /// <summary>
        /// Update a Project in the DB.
        /// </summary>
        /// <param name="Project">Project to update.</param>
        public void Update(Project Project)
        {
            _context.Project.Update(Project);
        }

        /// <summary>
        /// Delete a Project in the DB.
        /// </summary>
        /// <param name="Project">Project to delete.</param>
        public void Delete(Project Project)
        {
            _context.Project.Remove(Project);
        }
    }
}
