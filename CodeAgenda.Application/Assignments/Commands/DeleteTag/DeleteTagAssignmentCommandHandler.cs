using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Assignments;

namespace CodeAgenda.Application.Assignments.Commands.DeleteTag
{
    public class DeleteTagAssignmentCommandHandler
     : ICommandHandler<DeleteTagAssignmentCommand>
    {
        private readonly ITagRepository _tagAssignmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTagAssignmentCommandHandler(
            ITagRepository tagAssignmentRepository,
            IUnitOfWork unitOfWork)
        {
            _tagAssignmentRepository = tagAssignmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteTagAssignmentCommand request, CancellationToken cancellationToken)
        {
            var tagAssignmentToDelete = _tagAssignmentRepository.GetById(request.Id);
            if (tagAssignmentToDelete is null)
                return Task.CompletedTask;
            _tagAssignmentRepository.Delete(tagAssignmentToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }

}
