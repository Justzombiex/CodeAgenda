using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Users;

namespace CodeAgenda.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler
   : ICommandHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(
            IUserRepository UserRepository,
            IUnitOfWork unitOfWork)
        {
            _userRepository = UserRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userToDelete = _userRepository.GetById(request.Id);
            if (userToDelete is null)
                return Task.CompletedTask;
            _userRepository.Delete(userToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}


