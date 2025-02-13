using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Assignments;

namespace CodeAgenda.Application.Assignments.Commands.UpdateAssignment
{
    public record UpdateAssignmentCommand(Assignment Assignment) : ICommand;

}
