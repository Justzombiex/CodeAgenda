using CodeAgenda.Application.Abstract;
using CodeAgenda.Domain.Entities.Common;

namespace CodeAgenda.Application.Common.Commands.UpdateNotification
{
    public record UpdateNotificationCommand(Notification Notification) : ICommand;

}
