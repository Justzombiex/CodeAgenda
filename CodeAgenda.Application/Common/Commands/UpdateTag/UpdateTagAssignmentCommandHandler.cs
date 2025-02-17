using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Assignments;

namespace CodeAgenda.Application.Assignments.Commands.UpdateTag
{
    public class UpdateTagAssignmentCommandHandler
     : ICommandHandler<UpdateTagAssignmentCommand>
    {
        private readonly ITagRepository _tagAssignmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTagAssignmentCommandHandler(
            ITagRepository tagAssignmentRepository,
            IUnitOfWork unitOfWork)
        {
            _tagAssignmentRepository = tagAssignmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateTagAssignmentCommand request, CancellationToken cancellationToken)
        {
            _tagAssignmentRepository.Update(request.TagAssignment);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }

}
