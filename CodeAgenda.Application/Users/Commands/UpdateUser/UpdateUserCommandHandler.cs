using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Users;

namespace CodeAgenda.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler
        :ICommandHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(
            IUserRepository userRepository, 
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            //TODO: Validar que exista el usuario
            _userRepository.Update(request.User);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
