using CodeAgenda.Application.Abstract;
using CodeAgenda.Application.Common.Commands.UpdateNote;
using CodeAgenda.Contracts;
using CodeAgenda.Contracts.Projects;

namespace CodeAgenda.Application.Projects.Commands.UpdateNotification
{
    public class UpdateNotificationCommandHandler
      : ICommandHandler<UpdateNotificationCommand>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateNotificationCommandHandler(
            INotificationRepository notificationRepository,
            IUnitOfWork unitOfWork)
        {
            _notificationRepository = notificationRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            _notificationRepository.Update(request.Notification);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
