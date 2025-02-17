using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Common;

namespace CodeAgenda.Application.Common.Queries.GetTagByid
{
    public record GetTagByIdQuery(Guid Id) : IQuery<Tag?>;

}
