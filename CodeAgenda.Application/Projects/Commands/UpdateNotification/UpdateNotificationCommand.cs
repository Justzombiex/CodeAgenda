using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Projects;

namespace CodeAgenda.Application.Projects.Commands.UpdateNotification
{
    public record UpdateNotificationCommand(Notification Notification) : ICommand;

}
