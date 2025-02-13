using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.Application.Projects.Commands.UpdateProject
{
    public record UpdateProjectCommand(Project Project) : ICommand;
}
