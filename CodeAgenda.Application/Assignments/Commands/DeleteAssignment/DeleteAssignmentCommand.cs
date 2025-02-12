using CodeAgenda.Application.Abstract;

namespace CodeAgenda.Application.Assignments.Commands.DeleteAssignment
{
    public record DeleteAssignmentCommand(Guid Id) : ICommand;

}
