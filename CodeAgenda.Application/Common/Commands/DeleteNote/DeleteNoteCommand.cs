using CodeAgenda.Application.Abstract;

namespace CodeAgenda.Application.Common.Commands.DeleteNote
{
    public record DeleteNoteCommand(Guid Id) : ICommand;

}
