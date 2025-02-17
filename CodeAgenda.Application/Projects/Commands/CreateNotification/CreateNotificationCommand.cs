using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.Application.Projects.Commands.CreateNotification
{
    public record CreateNotificationCommand(
           string message,
            DateTime reminderDate,
            bool isRead,
            Project project) : ICommand<Notification>;
}
