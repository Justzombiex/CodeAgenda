using CodeAgenda.Application.Abstract;
using CodeAgenda.DataAccess.Abstract.Users;
using CodeAgenda.Domain.Entities.Users;

namespace CodeAgenda.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler
        : IQueryHandler<GetUserByIdQuery, User?>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(
            IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }

        public Task<User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_userRepository.GetById(request.Id));
        }
    }
}
