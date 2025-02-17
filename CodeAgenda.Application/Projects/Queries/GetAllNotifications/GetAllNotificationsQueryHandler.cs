using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts.Projects;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.Application.Projects.Queries.GetAllNotifications
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
