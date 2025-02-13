using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Projects;
using System.Drawing;

namespace CodeAgenda.Application.Projects.Commands.CreateCategory
{
    public record CreateCategoryCommand(
            string name,
            Color color,
            Project project) : ICommand<Category>;

}
