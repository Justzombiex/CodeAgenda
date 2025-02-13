using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Assignments;

namespace CodeAgenda.Application.Assignments.Commands.DeleteTag
{
    public class DeleteTagCommandHandler
     : ICommandHandler<DeleteTagCommand>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTagCommandHandler(
            ITagRepository tagRepository,
            IUnitOfWork unitOfWork)
        {
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var tagToDelete = _tagRepository.GetById(request.Id);
            if (tagToDelete is null)
                return Task.CompletedTask;
            _tagRepository.Delete(tagToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }

}
