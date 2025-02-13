using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Assignments;

namespace CodeAgenda.Application.Assignments.Commands.UpdateTag
{
    public record UpdateTagAssignmentCommand(TagAssignment TagAssignment) : ICommand;

}
