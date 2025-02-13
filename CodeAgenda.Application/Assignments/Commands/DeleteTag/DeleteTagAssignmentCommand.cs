using CodeAgenda.Application.Abstract;

namespace CodeAgenda.Application.Assignments.Commands.DeleteTag
{
    public record DeleteTagAssignmentCommand(Guid Id) : ICommand;

}
