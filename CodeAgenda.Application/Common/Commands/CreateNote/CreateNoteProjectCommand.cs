using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.Domain.Entities.Users;

namespace CodeAgenda.Application.Common.Commands.CreateNote
{
    public record CreateNoteProjectCommand(
            string content,
            User user,
            Project project) : ICommand<NoteProject>;

}
