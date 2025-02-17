using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.Application.Projects.Queries.GetAllNotifications
{
    public record GetAllNotificationsQuery : IQuery<IEnumerable<Notification>>;

}
