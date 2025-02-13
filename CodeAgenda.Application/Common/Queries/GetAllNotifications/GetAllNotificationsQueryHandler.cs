using CodeAgenda.Application.Abstract;
using CodeAgenda.DataAccess.Abstract.Common;
using CodeAgenda.Domain.Entities.Common;

namespace CodeAgenda.Application.Common.Queries.GetAllNotifications
{
    public class GetAllNotificationsQueryHandler
    : IQueryHandler<GetAllNotificationsQuery, IEnumerable<Notification>>
    {
        private readonly INotificationRepository _notificationRepository;

        public GetAllNotificationsQueryHandler(
            INotificationRepository notificationAssignmentRepository)
        {
            _notificationRepository = notificationAssignmentRepository;
        }

        public Task<IEnumerable<Notification>> Handle(GetAllNotificationsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_notificationRepository.GetAll());
        }
    }
}
