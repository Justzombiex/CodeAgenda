using CodeAgenda.Application.Abstract;
using CodeAgenda.Application.Common.Commands.CreateNote;
using CodeAgenda.Contracts;
using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.Application.Common.Commands.CreateNotification
{
    public class CreateNotificationCommandHandler
     : ICommandHandler<CreateNotificationCommand, Notification>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateNotificationCommandHandler(
            INotificationRepository notificationRepository,
            IUnitOfWork unitOfWork)
        {
            _notificationRepository = notificationRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Notification> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            Notification result = new Notification(
                request.message,
                request.reminderDate,
                request.isRead,
                request.project,
                Guid.NewGuid());

            _notificationRepository.Add(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
