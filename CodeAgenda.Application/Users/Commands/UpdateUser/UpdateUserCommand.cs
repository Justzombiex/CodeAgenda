using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Assignments;

namespace CodeAgenda.Application.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(Assignment Assignment) : ICommand;

}

