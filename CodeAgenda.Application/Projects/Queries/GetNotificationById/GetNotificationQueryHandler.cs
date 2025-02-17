using CodeAgenda.Application.Abstract;
using CodeAgenda.Contracts.Projects;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.Application.Projects.Queries.GetNotificationById
{
    public class GetNotificationByIdQueryHandler
     : IQueryHandler<GetNotificationByIdQuery, Notification?>
    {
        private readonly INotificationRepository _notificationRepository;

        public GetNotificationByIdQueryHandler(
            INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public Task<Notification?> Handle(GetNotificationByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_notificationRepository.GetById(request.Id));
        }
    }
}
