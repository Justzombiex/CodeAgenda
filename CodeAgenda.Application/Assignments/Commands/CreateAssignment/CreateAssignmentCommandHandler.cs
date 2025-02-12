using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Repositories.Assignments;
using CodeAgenda.Domain.Entities.Assignments;

namespace CodeAgenda.Application.Assignments.Commands.CreateAssignment
{
    public class CreateAssignmentCommandHandler
        : ICommandHandler<CreateAssignmentCommand, Assignment>
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAssignmentCommandHandler(
            IAssignmentRepository assignmentRepository, 
            IUnitOfWork unitOfWork)
        {
            _assignmentRepository = assignmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Assignment> Handle(CreateAssignmentCommand request, CancellationToken cancellationToken) 
        {
            Assignment result = new Assignment(
                request.name,
                request.description,
                request.finishDate,
                request.status,
                request.project,
                Guid.NewGuid());

            _assignmentRepository.Add(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
