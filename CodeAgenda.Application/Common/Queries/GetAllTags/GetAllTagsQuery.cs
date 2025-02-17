using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Common;

namespace CodeAgenda.Application.Common.Queries.GetAllTags
{
    public record GetAllTagsQuery : IQuery<IEnumerable<Tag>>;

}
