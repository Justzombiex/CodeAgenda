using CodeAgenda.Application.Abstract;
using CodeAgenda.DataAccess.Abstract.Projects;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.Application.Projects.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler
        : IQueryHandler<GetAllProjectsQuery, IEnumerable<Project>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsQueryHandler(
            IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Task<IEnumerable<Project>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_projectRepository.GetAll());
        }
    }
}
