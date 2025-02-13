using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Common;

namespace CodeAgenda.Application.Common.Commands.UpdateNote
{
    public class UpdateNoteAssignmentCommandHandler
     : ICommandHandler<UpdateNoteAssignmentCommand>
    {
        private readonly INoteRepository _noteAssignmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateNoteAssignmentCommandHandler(
            INoteRepository noteAssignmentRepository,
            IUnitOfWork unitOfWork)
        {
            _noteAssignmentRepository = noteAssignmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateNoteAssignmentCommand request, CancellationToken cancellationToken)
        {
            _noteAssignmentRepository.Update(request.NoteAssignment);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
