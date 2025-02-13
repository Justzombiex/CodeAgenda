using CodeAgenda.Application.Abstract;
using CodeAgenda.Application.Assignments.Commands.CreateAssignment;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Assignments;
using CodeAgenda.Domain.Entities.Assignments;

namespace CodeAgenda.Application.Assignments.Commands.CreateTag
{
    public class CreateTagAssignmentCommandHandler
    : ICommandHandler<CreateTagAssignmentCommand, TagAssignment>
    {
        private readonly ITagRepository _tagAssignmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTagAssignmentCommandHandler(
            ITagRepository tagAssignmentRepository,
            IUnitOfWork unitOfWork)
        {
            _tagAssignmentRepository = tagAssignmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<TagAssignment> Handle(CreateTagAssignmentCommand request, CancellationToken cancellationToken)
        {
            TagAssignment result = new TagAssignment(
                request.name,
                request.color,
                request.assignment,
                Guid.NewGuid());

            _tagAssignmentRepository.Add(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
