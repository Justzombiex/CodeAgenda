using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Repositories.Assignments;

namespace CodeAgenda.Application.Assignments.Commands.UpdateAssignment
{
    public class UpdateAssignmentCommandHandler
        :ICommandHandler<UpdateAssignmentCommand>
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAssignmentCommandHandler(
            IAssignmentRepository assignmentRepository, 
            IUnitOfWork unitOfWork)
        {
            _assignmentRepository = assignmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateAssignmentCommand request, CancellationToken cancellationToken)
        {
            _assignmentRepository.Update(request.Assignment);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
