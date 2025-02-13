using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Common;

namespace CodeAgenda.Application.Common.Commands.UpdateNote
{
    public record UpdateNoteProjectCommand(NoteProject NoteProject) : ICommand;

}
