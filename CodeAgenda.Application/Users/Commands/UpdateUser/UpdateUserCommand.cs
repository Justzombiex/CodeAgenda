using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Users;

namespace CodeAgenda.Application.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(User User) : ICommand;

}

