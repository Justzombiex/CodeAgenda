using CodeAgenda.Application.Abstract;
using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.Domain.Entities.Common;

namespace CodeAgenda.Application.Common.Queries.GetAllNotes
{
    public class GetAllNotesQueryHandler
    : IQueryHandler<GetAllNotesQuery, IEnumerable<Note>>
    {
        private readonly INoteRepository _noteRepository;

        public GetAllNotesQueryHandler(
            INoteRepository noteAssignmentRepository)
        {
            _noteRepository = noteAssignmentRepository;
        }

        public Task<IEnumerable<Note>> Handle(GetAllNotesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_noteRepository.GetAll());
        }
    }
}
