using CodeAgenda.Application.Abstract;

namespace CodeAgenda.Application.Projects.Commands.DeleteProject
{
    public record DeleteProjectCommand(Guid Id) : ICommand;

}
