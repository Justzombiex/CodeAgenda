using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Projects;
using System.Drawing;

namespace CodeAgenda.Application.Assignments.Commands.CreateTag
{
    public record CreateTagProjectCommand(
           string name,
           Color color,
           Project project) : ICommand<TagProject>;
}
