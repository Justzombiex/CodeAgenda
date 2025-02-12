using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Repositories.Assignments;

namespace CodeAgenda.Application.Assignments.Commands.DeleteAssignment
{
    public class DeleteAssignmentCommandHandler
       : ICommandHandler<DeleteAssignmentCommand>
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAssignmentCommandHandler(
            IAssignmentRepository assignmentRepository,
            IUnitOfWork unitOfWork)
        {
            _assignmentRepository = assignmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteAssignmentCommand request, CancellationToken cancellationToken)
        {
            var assignmentToDelete = _assignmentRepository.GetById(request.Id);
            if (assignmentToDelete is null)
                return Task.CompletedTask;
            _assignmentRepository.Delete(assignmentToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
