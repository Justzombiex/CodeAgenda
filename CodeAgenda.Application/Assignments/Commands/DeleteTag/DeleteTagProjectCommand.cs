using CodeAgenda.Application.Abstract;

namespace CodeAgenda.Application.Assignments.Commands.DeleteTag
{
    public record DeleteTagProjectCommand(Guid Id) : ICommand;
}
