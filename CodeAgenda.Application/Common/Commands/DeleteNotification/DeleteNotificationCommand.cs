using CodeAgenda.Application.Abstract;

namespace CodeAgenda.Application.Common.Commands.DeleteNotification
{
    public record DeleteNotificationCommand(Guid Id) : ICommand;

}
