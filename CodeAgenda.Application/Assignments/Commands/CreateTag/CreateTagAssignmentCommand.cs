using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Assignments;
using System.Drawing;

namespace CodeAgenda.Application.Assignments.Commands.CreateTag
{
    public record CreateTagAssignmentCommand(
            string name,
            Color color,
            Assignment assignment) : ICommand<TagAssignment>;

}
