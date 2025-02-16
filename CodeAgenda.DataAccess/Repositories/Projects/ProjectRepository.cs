using CodeAgenda.DataAccess.Abstract.Projects;
using CodeAgenda.DataAccess.Concrete;
using CodeAgenda.DataAccess.Repositories.Common;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.DataAccess.Repositories
{
    public class ProjectRepository
        : RepositoryBase, IProjectRepository
    {
        public ProjectRepository(ApplicationContext context) : base(context)
        {
        }

        public void Add(Project Project)
        {
            _context.Project.Add(Project);
        }

        Project? IProjectRepository.GetById(Guid id)
        {
            var project = _context.Project.FirstOrDefault(x => x.Id == id);
            if (project == null)
            {
                throw new Exception("Project not found");
            }
            return project;
        }

        public IEnumerable<Project> GetAll()
        {
            return _context.Project.ToList();
        }

        public void Update(Project Project)
        {
            _context.Project.Update(Project);
        }

        public void Delete(Project Project)
        {
            _context.Project.Remove(Project);
        }
    }
}
