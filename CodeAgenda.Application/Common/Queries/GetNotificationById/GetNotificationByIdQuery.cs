using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Common;

namespace CodeAgenda.Application.Common.Queries.GetNotificationById
{
    public record GetNotificationByIdQuery(Guid Id) : IQuery<Notification?>;

}
