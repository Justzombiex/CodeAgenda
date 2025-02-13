using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Assignments;

namespace CodeAgenda.Application.Assignments.Commands.DeleteTag
{
    public class DeleteTagProjectCommandHandler
     : ICommandHandler<DeleteTagProjectCommand>
    {
        private readonly ITagRepository _tagProjectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTagProjectCommandHandler(
            ITagRepository tagProjectRepository,
            IUnitOfWork unitOfWork)
        {
            _tagProjectRepository = tagProjectRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteTagProjectCommand request, CancellationToken cancellationToken)
        {
            var tagProjectToDelete = _tagProjectRepository.GetById(request.Id);
            if (tagProjectToDelete is null)
                return Task.CompletedTask;
            _tagProjectRepository.Delete(tagProjectToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }

}
