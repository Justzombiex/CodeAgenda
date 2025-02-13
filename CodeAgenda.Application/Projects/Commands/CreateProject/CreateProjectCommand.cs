using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.Domain.Entities.Users;

namespace CodeAgenda.Application.Projects.Commands.CreateProject
{
    public record CreateProjectCommand(
            string name,
            string description,
            DateTime startDate,
            DateTime endDate,
            User user) : ICommand<Project>;
}
