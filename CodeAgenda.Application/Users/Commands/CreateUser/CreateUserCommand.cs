using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Users;

namespace CodeAgenda.Application.Users.Commands.CreateUser
{
    public record CreateUserCommand(
            string name,
            string firstName,
            string email) : ICommand<User>;

}
