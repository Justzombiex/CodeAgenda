using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Users;

namespace CodeAgenda.Application.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(Guid Id) : IQuery<User?>;

}


