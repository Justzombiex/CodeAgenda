using CodeAgenda.Application.Abstract;
using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.Domain.Entities.Common;

namespace CodeAgenda.Application.Common.Queries.GetNoteById
{
    public class GetNoteByIdQueryHandler
     : IQueryHandler<GetNoteByIdQuery, Note?>
    {
        private readonly INoteRepository _noteRepository;

        public GetNoteByIdQueryHandler(
            INoteRepository projectRepository)
        {
            _noteRepository = projectRepository;
        }

        public Task<Note?> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_noteRepository.GetById(request.Id));
        }
    }
}
