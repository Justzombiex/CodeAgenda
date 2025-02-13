using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Projects;

namespace CodeAgenda.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler
        : ICommandHandler<DeleteProjectCommand>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProjectCommandHandler(
            IProjectRepository projectRepository,
            IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var ProjectToDelete = _projectRepository.GetById(request.Id);
            if (ProjectToDelete is null)
                return Task.CompletedTask;
            _projectRepository.Delete(ProjectToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
