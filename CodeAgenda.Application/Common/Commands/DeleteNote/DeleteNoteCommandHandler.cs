using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Common;

namespace CodeAgenda.Application.Common.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler
     : ICommandHandler<DeleteNoteCommand>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteNoteCommandHandler(
            INoteRepository noteRepository,
            IUnitOfWork unitOfWork)
        {
            _noteRepository = noteRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var NoteToDelete = _noteRepository.GetById(request.Id);
            if (NoteToDelete is null)
                return Task.CompletedTask;
            _noteRepository.Delete(NoteToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
