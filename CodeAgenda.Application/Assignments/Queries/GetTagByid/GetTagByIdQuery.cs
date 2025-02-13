using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Assignments;

namespace CodeAgenda.Application.Assignments.Queries.GetTagByid
{
    public record GetTagByIdQuery(Guid Id) : IQuery<Tag?>;

}
