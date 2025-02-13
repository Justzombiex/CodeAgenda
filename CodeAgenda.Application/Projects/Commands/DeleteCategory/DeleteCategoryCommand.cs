using CodeAgenda.Application.Abstract;

namespace CodeAgenda.Application.Projects.Commands.DeleteCategory
{
    public record DeleteCategoryCommand(Guid Id) : ICommand;

}
