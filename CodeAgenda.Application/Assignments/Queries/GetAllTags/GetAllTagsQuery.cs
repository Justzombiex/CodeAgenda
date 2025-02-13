using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Assignments;

namespace CodeAgenda.Application.Assignments.Queries.GetAllTags
{
    public record GetAllTagsQuery : IQuery<IEnumerable<Tag>>;

}
