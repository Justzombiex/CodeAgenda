using CodeAgenda.Application.Projects.Commands.CreateNotification;
using CodeAgenda.Application.Projects.Commands.DeleteNotification;
using CodeAgenda.Application.Projects.Commands.UpdateNotification;
using CodeAgenda.Application.Projects.Queries.GetAllNotifications;
using CodeAgenda.Application.Projects.Queries.GetNotificationById;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.DTO.Projects;

namespace CodeAgenda.Services.Interfaces.Projects
{
    public interface INotificationService
    {
        Task<NotificationDTO> Create(CreateNotificationCommand command);
        Task Delete(DeleteNotificationCommand command);
        Task Update(UpdateNotificationCommand command);
        Task<List<NotificationDTO>> GetAll(GetAllNotificationsQuery query);
        Task<NotificationDTO> GetById(GetNotificationByIdQuery query);
        Task<Notification?> GetNotificationById(Guid NotificationId);
    }
}
