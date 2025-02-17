using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.Application.Projects.Queries.GetNotificationById
{
    public record GetNotificationByIdQuery(Guid Id) : IQuery<Notification?>;

}
