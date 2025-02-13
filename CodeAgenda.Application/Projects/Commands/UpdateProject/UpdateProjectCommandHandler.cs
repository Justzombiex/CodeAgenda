using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Projects;

namespace CodeAgenda.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler
    : ICommandHandler<UpdateProjectCommand>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProjectCommandHandler(
            IProjectRepository projectRepository,
            IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            _projectRepository.Update(request.Project);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
