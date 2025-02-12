using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.Domain.Entities.Types;

namespace CodeAgenda.Application.Assignments.Commands.CreateAssignment
{
    public record CreateAssignmentCommand(
            string name,
            string description,
            DateTime finishDate,
            Status status,
            Project project) : ICommand<Assignment>;

}
