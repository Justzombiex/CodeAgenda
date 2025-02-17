using CodeAgenda.Application.Abstract;

namespace CodeAgenda.Application.Projects.Commands.DeleteNotification
{
    public record DeleteNotificationCommand(Guid Id) : ICommand;

}
