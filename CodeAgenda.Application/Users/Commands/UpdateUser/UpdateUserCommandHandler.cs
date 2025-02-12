using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Repositories.Assignments;

namespace CodeAgenda.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler
        :ICommandHandler<UpdateUserCommand>
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(
            IAssignmentRepository assignmentRepository, 
            IUnitOfWork unitOfWork)
        {
            _assignmentRepository = assignmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            _assignmentRepository.Update(request.Assignment);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
