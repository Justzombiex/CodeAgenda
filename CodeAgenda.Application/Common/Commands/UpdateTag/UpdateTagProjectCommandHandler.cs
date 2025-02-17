using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Assignments;

namespace CodeAgenda.Application.Assignments.Commands.UpdateTag
{
    public class UpdateTagProjectCommandHandler
    : ICommandHandler<UpdateTagProjectCommand>
    {
        private readonly ITagRepository _tagProjectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTagProjectCommandHandler(
            ITagRepository tagProjectRepository,
            IUnitOfWork unitOfWork)
        {
            _tagProjectRepository = tagProjectRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateTagProjectCommand request, CancellationToken cancellationToken)
        {
            _tagProjectRepository.Update(request.TagProject);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }

}
