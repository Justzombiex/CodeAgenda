using CodeAgenda.Application.Abstract;

namespace CodeAgenda.Application.Users.Commands.DeleteUser
{
    public record DeleteUserCommand(Guid Id) : ICommand;

}
