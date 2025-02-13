using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Projects;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler
        : ICommandHandler<CreateProjectCommand, Project>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProjectCommandHandler(
            IProjectRepository projectRepository,
            IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Project> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            Project result = new Project(
                request.name,
                request.description,
                request.startDate,
                request.endDate,
                request.user,
                Guid.NewGuid());

            _projectRepository.Add(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
