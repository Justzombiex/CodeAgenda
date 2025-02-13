using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.Domain.Entities.Common;

namespace CodeAgenda.Application.Common.Commands.CreateNote
{
    public class CreateNoteAssignmentCommandHandler
       : ICommandHandler<CreateNoteAssignmentCommand, NoteAssignment>
    {
        private readonly INoteRepository _noteAssignmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateNoteAssignmentCommandHandler(
            INoteRepository noteAssignmentRepository,
            IUnitOfWork unitOfWork)
        {
            _noteAssignmentRepository = noteAssignmentRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<NoteAssignment> Handle(CreateNoteAssignmentCommand request, CancellationToken cancellationToken)
        {
            NoteAssignment result = new NoteAssignment(
                request.content,
                request.user,
                request.assignment,
                Guid.NewGuid());

            _noteAssignmentRepository.Add(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
