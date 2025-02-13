using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.Domain.Entities.Users;

namespace CodeAgenda.Application.Common.Commands.CreateNote
{
    public record CreateNoteAssignmentCommand(
            string content,
            User user,
            Assignment assignment) : ICommand<NoteAssignment>;
}
