using AutoMapper;
using CodeAgenda.Application.Common.Queries.GetTagByid;
using CodeAgenda.Application.Projects.Commands.CreateNotification;
using CodeAgenda.Application.Projects.Commands.DeleteNotification;
using CodeAgenda.Application.Projects.Commands.UpdateNotification;
using CodeAgenda.Application.Projects.Queries.GetAllNotifications;
using CodeAgenda.Application.Projects.Queries.GetNotificationById;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.DTO.Projects;
using CodeAgenda.Services.Interfaces.Projects;
using MediatR;

namespace CodeAgenda.Services.Services.Projects
{
    public class NotificationService : INotificationService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public NotificationService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<NotificationDTO> Create(CreateNotificationCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return _mapper.Map<NotificationDTO>(result);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task Delete(DeleteNotificationCommand command)
        {
            try
            {
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<List<NotificationDTO>> GetAll(GetAllNotificationsQuery query)
        {
            try
            {
                var notifications = await _mediator.Send(query);
                var notification = _mapper.Map<List<NotificationDTO>>(notifications.OfType<Notification>());
                return notification;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<NotificationDTO?> GetById(GetNotificationByIdQuery query)
        {
            try
            {
                var notification = await _mediator.Send(query);
                var notificationDTO = _mapper.Map<NotificationDTO>(notification);
                return notificationDTO;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task Update(UpdateNotificationCommand command)
        {
            try
            {
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<Notification?> GetNotificationById(Guid notificationId)
        {
            var query = new GetTagByIdQuery(notificationId);
            var notificationDto = await _mediator.Send(query);
            var notification = _mapper.Map<Notification>(notificationDto);
            return notification;
        }
    }
}
