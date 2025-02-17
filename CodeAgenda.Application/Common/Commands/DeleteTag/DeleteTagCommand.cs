using CodeAgenda.Application.Abstract;

namespace CodeAgenda.Application.Assignments.Commands.DeleteTag
{
    public record DeleteTagCommand(Guid Id) : ICommand;

}
