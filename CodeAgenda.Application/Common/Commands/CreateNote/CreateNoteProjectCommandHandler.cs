using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.Domain.Entities.Common;

namespace CodeAgenda.Application.Common.Commands.CreateNote
{
    public class CreateNoteProjectCommandHandler
      : ICommandHandler<CreateNoteProjectCommand, NoteProject>
    {
        private readonly INoteRepository _noteProjectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateNoteProjectCommandHandler(
            INoteRepository noteProjectRepository,
            IUnitOfWork unitOfWork)
        {
            _noteProjectRepository = noteProjectRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<NoteProject> Handle(CreateNoteProjectCommand request, CancellationToken cancellationToken)
        {
            NoteProject result = new NoteProject(
                request.content,
                request.user,
                request.project,
                Guid.NewGuid());

            _noteProjectRepository.Add(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
