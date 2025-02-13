using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Common;

namespace CodeAgenda.Application.Common.Queries.GetAllNotifications
{
    public record GetAllNotificationsQuery : IQuery<IEnumerable<Notification>>;

}
