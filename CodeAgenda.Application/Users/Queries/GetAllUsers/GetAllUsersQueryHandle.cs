using CodeAgenda.Application.Abstract;
using CodeAgenda.DataAccess.Abstract.Users;
using CodeAgenda.DataAccess.Repositories.Assignments;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Users;

namespace CodeAgenda.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler
        : IQueryHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(
            IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }

        public Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_userRepository.GetAll());
        }
    }
}
