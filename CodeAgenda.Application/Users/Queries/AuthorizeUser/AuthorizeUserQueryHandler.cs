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
            var user = _userRepository.GetByEmail(request.Email);
            if (user == null) return Task.FromResult<User?>(null);

            return Task.FromResult(user.VerifyPassword(request.Password) ? user : null);
        }
    }
}
