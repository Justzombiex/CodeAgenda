using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Common;

namespace CodeAgenda.Application.Common.Commands.UpdateNote
{
    public class UpdateNoteProjectCommandHandler
      : ICommandHandler<UpdateNoteProjectCommand>
    {
        private readonly INoteRepository _noteProjectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateNoteProjectCommandHandler(
            INoteRepository noteProjectRepository,
            IUnitOfWork unitOfWork)
        {
            _noteProjectRepository = noteProjectRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateNoteProjectCommand request, CancellationToken cancellationToken)
        {
            _noteProjectRepository.Update(request.NoteProject);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
