using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Common;

namespace CodeAgenda.Application.Common.Queries.GetAllNotes
{
    public record GetAllNotesQuery : IQuery<IEnumerable<Note>>;

}
