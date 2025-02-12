using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Users;

namespace CodeAgenda.Application.Users.Queries.GetAllUsers
{
    public record GetAllUsersQuery : IQuery<IEnumerable<User>>;

}
