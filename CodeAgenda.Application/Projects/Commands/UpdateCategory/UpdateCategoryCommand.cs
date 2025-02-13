using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.Application.Projects.Commands.UpdateCategory
{
    public record UpdateCategoryCommand(Category Category) : ICommand;

}
