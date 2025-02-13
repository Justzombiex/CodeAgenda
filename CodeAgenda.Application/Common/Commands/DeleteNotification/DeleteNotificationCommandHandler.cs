using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Common;

namespace CodeAgenda.Application.Common.Commands.DeleteNotification
{
    public class DeleteNotificationCommandHandler
     : ICommandHandler<DeleteNotificationCommand>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteNotificationCommandHandler(
            INotificationRepository notificationRepository,
            IUnitOfWork unitOfWork)
        {
            _notificationRepository = notificationRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            var NotificationToDelete = _notificationRepository.GetById(request.Id);
            if (NotificationToDelete is null)
                return Task.CompletedTask;
            _notificationRepository.Delete(NotificationToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
