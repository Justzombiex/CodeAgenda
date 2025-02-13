using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Common;

namespace CodeAgenda.Application.Common.Queries.GetNoteById
{
    public record GetNoteByIdQuery(Guid Id) : IQuery<Note?>;

}
