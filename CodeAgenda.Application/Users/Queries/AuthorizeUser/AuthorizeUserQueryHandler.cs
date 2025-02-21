using CodeAgenda.Application.Abstract;
using CodeAgenda.DataAccess.Abstract.Users;
using CodeAgenda.Domain.Entities.Users;

namespace CodeAgenda.Application.Users.Queries.AuthorizeUser
{
    public class AuthorizeUserQueryHandler
        : IQueryHandler<AuthorizeUserQuery, User?>
    {
        private readonly IUserRepository _userRepository;

        public AuthorizeUserQueryHandler(
           IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }

        public Task<User?> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_userRepository.AuthorizeUser(request.Email, request.Password));
        }
    }
}
