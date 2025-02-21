using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Users;

namespace CodeAgenda.Application.Users.Queries.AuthorizeUser
{
    public record AuthorizeUserQuery(string Email, string Password) : IQuery<User?>;


}
