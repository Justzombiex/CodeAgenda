using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.Application.Projects.Queries.GetCategoryById
{
    public record GetCategoryByIdQuery(Guid Id) : IQuery<Category?>;

}
