using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Users;
using CodeAgenda.Domain.Entities.Users;

namespace CodeAgenda.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler
        : ICommandHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(
            IUserRepository UserRepository,
            IUnitOfWork unitOfWork)
        {
            _userRepository = UserRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User result = new User(
                request.name,
                request.firstName,
                request.email,
                Guid.NewGuid());

            _userRepository.Add(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
