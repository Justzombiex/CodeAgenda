using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.Application.Projects.Queries.GetAllCategories
{
    public record GetAllCategoriesQuery : IQuery<IEnumerable<Category>>;

}
