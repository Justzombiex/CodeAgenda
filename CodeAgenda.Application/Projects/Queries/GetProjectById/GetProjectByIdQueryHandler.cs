using CodeAgenda.Application.Abstract;
using CodeAgenda.DataAccess.Abstract.Projects;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.Application.Projects.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler
     : IQueryHandler<GetProjectByIdQuery, Project?>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectByIdQueryHandler(
            IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Task<Project?> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_projectRepository.GetById(request.Id));
        }
    }
}
